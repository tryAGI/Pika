using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using tryAGI.RealtimeAvatar;

namespace Pika;

/// <summary>
/// Adapter wrapping the Pika Sessions API to implement <see cref="IRealtimeAvatarClient"/>.
/// Pika joins video meetings (Google Meet/Zoom) as an AI avatar bot.
/// Unlike D-ID/Simli, video/audio frames are delivered to the meeting participants,
/// not streamed back to the SDK consumer.
/// </summary>
[SuppressMessage("Design", "CA1054:URI parameters should not be strings",
    Justification = "Generated API uses string for meet URL")]
public sealed class PikaRealtimeAvatarClient : IRealtimeAvatarClient
{
    private readonly PikaClient _client;
    private readonly string _sessionId;
    private bool _disposed;

    private PikaRealtimeAvatarClient(PikaClient client, string sessionId)
    {
        _client = client;
        _sessionId = sessionId;
    }

    /// <summary>
    /// Joins a meeting with an AI avatar and returns the adapter.
    /// </summary>
    /// <param name="client">The Pika API client.</param>
    /// <param name="meetUrl">Meeting URL to join (Google Meet or Zoom).</param>
    /// <param name="botName">Display name for the avatar bot in the meeting.</param>
    /// <param name="platform">The video meeting platform (GoogleMeet or Zoom).</param>
    /// <param name="avatarImage">Avatar reference image bytes.</param>
    /// <param name="avatarImageName">Filename for the avatar image (e.g. "avatar.png").</param>
    /// <param name="voiceId">Voice ID for avatar speech synthesis.</param>
    /// <param name="meetingPassword">Optional meeting password.</param>
    /// <param name="systemPrompt">Optional system prompt to guide avatar behavior.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A connected <see cref="PikaRealtimeAvatarClient"/>.</returns>
    public static async Task<PikaRealtimeAvatarClient> ConnectAsync(
        PikaClient client,
        string meetUrl,
        string botName,
        MeetingPlatform platform,
        byte[] avatarImage,
        string avatarImageName,
        string voiceId,
        string? meetingPassword = null,
        string? systemPrompt = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(meetUrl);
        ArgumentNullException.ThrowIfNull(botName);
        ArgumentNullException.ThrowIfNull(avatarImage);
        ArgumentNullException.ThrowIfNull(avatarImageName);
        ArgumentNullException.ThrowIfNull(voiceId);

        var response = await client.Sessions.CreateMeetingSessionAsync(
            image: avatarImage,
            imagename: avatarImageName,
            voiceId: voiceId,
            meetUrl: meetUrl,
            botName: botName,
            platform: platform,
            meetingPassword: meetingPassword,
            systemPrompt: systemPrompt,
            cancellationToken: cancellationToken).ConfigureAwait(false);

        return new PikaRealtimeAvatarClient(client, response.SessionId);
    }

    /// <summary>
    /// Gets the meeting session ID.
    /// </summary>
    public string SessionId => _sessionId;

    /// <inheritdoc />
    public bool IsConnected => !_disposed;

    /// <inheritdoc />
    public Task SendTextAsync(string text, CancellationToken cancellationToken = default)
    {
        // Pika meeting bots receive text via system prompt at creation time.
        // There is no real-time text injection API during the meeting.
        throw new NotSupportedException(
            "Pika meeting sessions don't support real-time text injection. " +
            "Set the system prompt when connecting via ConnectAsync.");
    }

    /// <inheritdoc />
    public Task SendAudioAsync(ReadOnlyMemory<byte> pcm16Audio, CancellationToken cancellationToken = default)
    {
        // Pika avatars listen via the meeting's own audio channel.
        throw new NotSupportedException(
            "Pika meeting sessions don't support direct audio input. " +
            "The avatar listens via the meeting's audio channel.");
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<AvatarVideoFrame> ReceiveVideoFramesAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Pika renders video directly in the meeting -- no frames come back to the SDK.
        await Task.CompletedTask.ConfigureAwait(false);
        yield break;
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<AvatarAudioFrame> ReceiveAudioFramesAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        // Pika renders audio directly in the meeting -- no frames come back to the SDK.
        await Task.CompletedTask.ConfigureAwait(false);
        yield break;
    }

    /// <summary>
    /// Gets the current status of the meeting session.
    /// Polls the Pika API for session state (created, pending, ready, error, closed)
    /// along with connection details (video worker, video stream, meeting bot).
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The current session status and connection details.</returns>
    public async Task<SessionStatusResponse> GetSessionStatusAsync(
        CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        return await _client.Sessions.GetSessionAsync(
            sessionId: _sessionId,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Polls the session status until it reaches "ready" or "error", or the timeout expires.
    /// </summary>
    /// <param name="timeout">Maximum time to wait. Defaults to 90 seconds.</param>
    /// <param name="pollInterval">Time between polls. Defaults to 2 seconds.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The final session status response.</returns>
    /// <exception cref="TimeoutException">Thrown if the session does not become ready within the timeout.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the session enters an error state.</exception>
    public async Task<SessionStatusResponse> WaitUntilReadyAsync(
        TimeSpan? timeout = null,
        TimeSpan? pollInterval = null,
        CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        var effectiveTimeout = timeout ?? TimeSpan.FromSeconds(90);
        var effectivePollInterval = pollInterval ?? TimeSpan.FromSeconds(2);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(effectiveTimeout);

        while (!cts.Token.IsCancellationRequested)
        {
            var status = await GetSessionStatusAsync(cts.Token).ConfigureAwait(false);

            if (status.Status == SessionStatus.Ready)
                return status;

            if (status.Status == SessionStatus.Error)
                throw new InvalidOperationException(
                    $"Pika meeting session entered error state: {status.ErrorMessage}");

            if (status.Status == SessionStatus.Closed)
                throw new InvalidOperationException("Pika meeting session was closed unexpectedly.");

            await Task.Delay(effectivePollInterval, cts.Token).ConfigureAwait(false);
        }

        throw new TimeoutException(
            $"Pika meeting session did not become ready within {effectiveTimeout.TotalSeconds}s.");
    }

    /// <inheritdoc />
    [SuppressMessage("Design", "CA1031:Do not catch general exception types",
        Justification = "Best effort cleanup -- session may already be closed")]
    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;
        _disposed = true;

        // Leave the meeting by deleting the session.
        try
        {
            await _client.Sessions.DeleteSessionAsync(
                sessionId: _sessionId).ConfigureAwait(false);
        }
        catch
        {
            // Best effort cleanup -- the session may already be closed.
        }
    }
}
