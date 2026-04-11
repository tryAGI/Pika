
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class SessionStatusResponse
    {
        /// <summary>
        /// Unique session identifier
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("session_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SessionId { get; set; }

        /// <summary>
        /// Session lifecycle status
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Pika.JsonConverters.SessionStatusJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Pika.SessionStatus Status { get; set; }

        /// <summary>
        /// Whether the video processing worker is connected
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("video_worker_connected")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool VideoWorkerConnected { get; set; }

        /// <summary>
        /// Whether the video stream is connected
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("video_connected")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool VideoConnected { get; set; }

        /// <summary>
        /// Whether the bot has joined the meeting
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("meeting_bot_connected")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool MeetingBotConnected { get; set; }

        /// <summary>
        /// Error details if status is error
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("error_message")]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStatusResponse" /> class.
        /// </summary>
        /// <param name="sessionId">
        /// Unique session identifier
        /// </param>
        /// <param name="status">
        /// Session lifecycle status
        /// </param>
        /// <param name="videoWorkerConnected">
        /// Whether the video processing worker is connected
        /// </param>
        /// <param name="videoConnected">
        /// Whether the video stream is connected
        /// </param>
        /// <param name="meetingBotConnected">
        /// Whether the bot has joined the meeting
        /// </param>
        /// <param name="errorMessage">
        /// Error details if status is error
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public SessionStatusResponse(
            string sessionId,
            global::Pika.SessionStatus status,
            bool videoWorkerConnected,
            bool videoConnected,
            bool meetingBotConnected,
            string? errorMessage)
        {
            this.SessionId = sessionId ?? throw new global::System.ArgumentNullException(nameof(sessionId));
            this.Status = status;
            this.VideoWorkerConnected = videoWorkerConnected;
            this.VideoConnected = videoConnected;
            this.MeetingBotConnected = meetingBotConnected;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStatusResponse" /> class.
        /// </summary>
        public SessionStatusResponse()
        {
        }
    }
}