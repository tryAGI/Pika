#nullable enable

namespace Pika
{
    public partial interface ISessionsClient
    {
        /// <summary>
        /// Create a meeting session with avatar<br/>
        /// Joins a Google Meet or Zoom call with an AI-powered avatar.<br/>
        /// Requires a reference image for the avatar appearance, a voice ID for speech synthesis,<br/>
        /// and the meeting URL to join.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.MeetingSessionResponse> CreateMeetingSessionAsync(

            global::Pika.CreateMeetingSessionRequest request,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a meeting session with avatar<br/>
        /// Joins a Google Meet or Zoom call with an AI-powered avatar.<br/>
        /// Requires a reference image for the avatar appearance, a voice ID for speech synthesis,<br/>
        /// and the meeting URL to join.
        /// </summary>
        /// <param name="image">
        /// Avatar reference image (binary upload)
        /// </param>
        /// <param name="imagename">
        /// Avatar reference image (binary upload)
        /// </param>
        /// <param name="voiceId">
        /// Voice ID for avatar speech synthesis
        /// </param>
        /// <param name="meetUrl">
        /// Meeting URL to join
        /// </param>
        /// <param name="botName">
        /// Display name for the avatar bot in the meeting
        /// </param>
        /// <param name="platform">
        /// The video meeting platform
        /// </param>
        /// <param name="meetingPassword">
        /// Optional meeting password
        /// </param>
        /// <param name="systemPrompt">
        /// Optional system prompt to guide avatar behavior
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.MeetingSessionResponse> CreateMeetingSessionAsync(
            byte[] image,
            string imagename,
            string voiceId,
            string meetUrl,
            string botName,
            global::Pika.MeetingPlatform platform,
            string? meetingPassword = default,
            string? systemPrompt = default,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}