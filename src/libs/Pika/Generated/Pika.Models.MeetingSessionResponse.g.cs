
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MeetingSessionResponse
    {
        /// <summary>
        /// Unique session identifier
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("session_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SessionId { get; set; }

        /// <summary>
        /// The video meeting platform
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("platform")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Pika.JsonConverters.MeetingPlatformJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Pika.MeetingPlatform Platform { get; set; }

        /// <summary>
        /// Initial session status
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Status { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingSessionResponse" /> class.
        /// </summary>
        /// <param name="sessionId">
        /// Unique session identifier
        /// </param>
        /// <param name="platform">
        /// The video meeting platform
        /// </param>
        /// <param name="status">
        /// Initial session status
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public MeetingSessionResponse(
            string sessionId,
            global::Pika.MeetingPlatform platform,
            string status)
        {
            this.SessionId = sessionId ?? throw new global::System.ArgumentNullException(nameof(sessionId));
            this.Platform = platform;
            this.Status = status ?? throw new global::System.ArgumentNullException(nameof(status));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingSessionResponse" /> class.
        /// </summary>
        public MeetingSessionResponse()
        {
        }
    }
}