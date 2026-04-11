
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CloneVoiceResponse
    {
        /// <summary>
        /// Unique identifier for the cloned voice
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("voice_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string VoiceId { get; set; }

        /// <summary>
        /// Voice provider service name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("provider")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Provider { get; set; }

        /// <summary>
        /// Timestamp when the voice was cloned
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("cloned_at")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime ClonedAt { get; set; }

        /// <summary>
        /// Reference to the source audio file
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("source_audio")]
        public string? SourceAudio { get; set; }

        /// <summary>
        /// Data retention policy notice
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("retention_warning")]
        public string? RetentionWarning { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CloneVoiceResponse" /> class.
        /// </summary>
        /// <param name="voiceId">
        /// Unique identifier for the cloned voice
        /// </param>
        /// <param name="provider">
        /// Voice provider service name
        /// </param>
        /// <param name="clonedAt">
        /// Timestamp when the voice was cloned
        /// </param>
        /// <param name="sourceAudio">
        /// Reference to the source audio file
        /// </param>
        /// <param name="retentionWarning">
        /// Data retention policy notice
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CloneVoiceResponse(
            string voiceId,
            string provider,
            global::System.DateTime clonedAt,
            string? sourceAudio,
            string? retentionWarning)
        {
            this.VoiceId = voiceId ?? throw new global::System.ArgumentNullException(nameof(voiceId));
            this.Provider = provider ?? throw new global::System.ArgumentNullException(nameof(provider));
            this.ClonedAt = clonedAt;
            this.SourceAudio = sourceAudio;
            this.RetentionWarning = retentionWarning;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloneVoiceResponse" /> class.
        /// </summary>
        public CloneVoiceResponse()
        {
        }
    }
}