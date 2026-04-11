
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CreateMeetingSessionRequest
    {
        /// <summary>
        /// Avatar reference image (binary upload)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("image")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required byte[] Image { get; set; }

        /// <summary>
        /// Avatar reference image (binary upload)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("imagename")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Imagename { get; set; }

        /// <summary>
        /// Voice ID for avatar speech synthesis
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("voice_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string VoiceId { get; set; }

        /// <summary>
        /// Meeting URL to join
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("meet_url")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string MeetUrl { get; set; }

        /// <summary>
        /// Display name for the avatar bot in the meeting
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("bot_name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string BotName { get; set; }

        /// <summary>
        /// The video meeting platform
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("platform")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Pika.JsonConverters.MeetingPlatformJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Pika.MeetingPlatform Platform { get; set; }

        /// <summary>
        /// Optional meeting password
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("meeting_password")]
        public string? MeetingPassword { get; set; }

        /// <summary>
        /// Optional system prompt to guide avatar behavior
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("system_prompt")]
        public string? SystemPrompt { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMeetingSessionRequest" /> class.
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
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CreateMeetingSessionRequest(
            byte[] image,
            string imagename,
            string voiceId,
            string meetUrl,
            string botName,
            global::Pika.MeetingPlatform platform,
            string? meetingPassword,
            string? systemPrompt)
        {
            this.Image = image ?? throw new global::System.ArgumentNullException(nameof(image));
            this.Imagename = imagename ?? throw new global::System.ArgumentNullException(nameof(imagename));
            this.VoiceId = voiceId ?? throw new global::System.ArgumentNullException(nameof(voiceId));
            this.MeetUrl = meetUrl ?? throw new global::System.ArgumentNullException(nameof(meetUrl));
            this.BotName = botName ?? throw new global::System.ArgumentNullException(nameof(botName));
            this.Platform = platform;
            this.MeetingPassword = meetingPassword;
            this.SystemPrompt = systemPrompt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMeetingSessionRequest" /> class.
        /// </summary>
        public CreateMeetingSessionRequest()
        {
        }
    }
}