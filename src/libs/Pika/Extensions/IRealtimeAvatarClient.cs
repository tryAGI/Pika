#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
#pragma warning disable CS3003 // Type is not CLS-compliant
#pragma warning disable CA1819 // Properties should not return arrays

namespace tryAGI.RealtimeAvatar;

/// <summary>
/// Common abstraction for realtime avatar streaming providers.
/// Implementations handle WebRTC/WebSocket transport specifics.
/// </summary>
public interface IRealtimeAvatarClient : IAsyncDisposable
{
    /// <summary>
    /// Gets whether the session is currently connected.
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// Sends text for the avatar to speak. The avatar will lip-sync and respond via video/audio streams.
    /// </summary>
    Task SendTextAsync(string text, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends raw PCM16 audio for the avatar to lip-sync to.
    /// </summary>
    Task SendAudioAsync(ReadOnlyMemory<byte> pcm16Audio, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives encoded video frames from the avatar.
    /// </summary>
    IAsyncEnumerable<AvatarVideoFrame> ReceiveVideoFramesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives encoded audio frames from the avatar.
    /// </summary>
    IAsyncEnumerable<AvatarAudioFrame> ReceiveAudioFramesAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// An encoded video frame from an avatar stream.
/// </summary>
public sealed record AvatarVideoFrame(byte[] Data, string Codec, uint Timestamp);

/// <summary>
/// An encoded audio frame from an avatar stream.
/// </summary>
public sealed record AvatarAudioFrame(byte[] Data, string Codec, uint DurationMs);
