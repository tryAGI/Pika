
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class DeleteSessionResponse
    {
        /// <summary>
        /// Unique session identifier
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("session_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SessionId { get; set; }

        /// <summary>
        /// Final status (closed)
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
        /// Initializes a new instance of the <see cref="DeleteSessionResponse" /> class.
        /// </summary>
        /// <param name="sessionId">
        /// Unique session identifier
        /// </param>
        /// <param name="status">
        /// Final status (closed)
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public DeleteSessionResponse(
            string sessionId,
            string status)
        {
            this.SessionId = sessionId ?? throw new global::System.ArgumentNullException(nameof(sessionId));
            this.Status = status ?? throw new global::System.ArgumentNullException(nameof(status));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSessionResponse" /> class.
        /// </summary>
        public DeleteSessionResponse()
        {
        }
    }
}