using Microsoft.Extensions.AI;

namespace Pika;

/// <summary>
/// Extensions for using PikaClient as MEAI tools with any IChatClient.
/// </summary>
public static class PikaToolExtensions
{
    /// <summary>
    /// Creates an <see cref="AIFunction"/> that checks the developer account balance,
    /// suitable for use as a tool with any IChatClient.
    /// </summary>
    /// <param name="client">The Pika client to use.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    [CLSCompliant(false)]
    public static AIFunction AsGetBalanceTool(
        this PikaClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (CancellationToken cancellationToken) =>
            {
                var response = await client.Developer.GetDeveloperBalanceAsync(
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return $"Balance: {response.Balance} {response.Currency}";
            },
            name: "PikaGetBalance",
            description: "Gets the current credit balance and currency for the authenticated Pika developer account.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that joins a Google Meet or Zoom call with an AI avatar,
    /// suitable for use as a tool with any IChatClient.
    /// </summary>
    /// <param name="client">The Pika client to use.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    [CLSCompliant(false)]
    public static AIFunction AsJoinMeetingTool(
        this PikaClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string meetUrl, string voiceId, string botName, string platform, string? systemPrompt, CancellationToken cancellationToken) =>
            {
                var meetingPlatform = platform.ToUpperInvariant() switch
                {
                    "ZOOM" => MeetingPlatform.Zoom,
                    _ => MeetingPlatform.GoogleMeet,
                };

                var response = await client.Sessions.CreateMeetingSessionAsync(
                    image: [],
                    imagename: "avatar.png",
                    voiceId: voiceId,
                    meetUrl: meetUrl,
                    botName: botName,
                    platform: meetingPlatform,
                    systemPrompt: systemPrompt,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return $"Session created: {response.SessionId}, Platform: {response.Platform}, Status: {response.Status}";
            },
            name: "PikaJoinMeeting",
            description: "Joins a Google Meet or Zoom call with a Pika AI avatar. Requires a meeting URL, voice ID, bot display name, and platform (google_meet or zoom). Note: avatar image must be provided separately via the API.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that gets the status of a meeting session,
    /// suitable for use as a tool with any IChatClient.
    /// </summary>
    /// <param name="client">The Pika client to use.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    [CLSCompliant(false)]
    public static AIFunction AsGetSessionStatusTool(
        this PikaClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string sessionId, CancellationToken cancellationToken) =>
            {
                var response = await client.Sessions.GetSessionAsync(
                    sessionId: sessionId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var parts = new List<string>
                {
                    $"Session: {response.SessionId}",
                    $"Status: {response.Status}",
                    $"Video Worker: {response.VideoWorkerConnected}",
                    $"Video: {response.VideoConnected}",
                    $"Meeting Bot: {response.MeetingBotConnected}",
                };

                if (response.ErrorMessage is { Length: > 0 } error)
                {
                    parts.Add($"Error: {error}");
                }

                return string.Join("\n", parts);
            },
            name: "PikaGetSessionStatus",
            description: "Gets the current status and connection details for a Pika meeting session. Returns session status, video/audio connection states, and any error messages.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that ends a meeting session,
    /// suitable for use as a tool with any IChatClient.
    /// </summary>
    /// <param name="client">The Pika client to use.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    [CLSCompliant(false)]
    public static AIFunction AsLeaveMeetingTool(
        this PikaClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string sessionId, CancellationToken cancellationToken) =>
            {
                var response = await client.Sessions.DeleteSessionAsync(
                    sessionId: sessionId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return $"Session {response.SessionId} ended. Status: {response.Status}";
            },
            name: "PikaLeaveMeeting",
            description: "Ends a Pika meeting session, causing the AI avatar bot to leave the call. Requires the session ID.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that generates an AI avatar image from a text prompt,
    /// suitable for use as a tool with any IChatClient.
    /// </summary>
    /// <param name="client">The Pika client to use.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    [CLSCompliant(false)]
    public static AIFunction AsGenerateAvatarTool(
        this PikaClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string prompt, string? model, CancellationToken cancellationToken) =>
            {
                var response = await client.Avatar.GenerateAvatarAsync(
                    prompt: prompt,
                    model: model,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var parts = new List<string> { $"Avatar URL: {response.Url}" };
                if (response.RevisedPrompt is { Length: > 0 } revisedPrompt)
                {
                    parts.Add($"Revised prompt: {revisedPrompt}");
                }

                return string.Join("\n", parts);
            },
            name: "PikaGenerateAvatar",
            description: "Generates an AI avatar image from a text prompt. The generated image can be used as the avatar appearance in Pika meeting sessions. Optionally specify a model (default: gpt-image-1-mini).");
    }
}
