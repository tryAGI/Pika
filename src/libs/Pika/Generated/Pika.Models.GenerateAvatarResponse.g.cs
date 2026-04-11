
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GenerateAvatarResponse
    {
        /// <summary>
        /// URL of the generated avatar image
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("url")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Url { get; set; }

        /// <summary>
        /// The prompt as revised by the model
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("revised_prompt")]
        public string? RevisedPrompt { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateAvatarResponse" /> class.
        /// </summary>
        /// <param name="url">
        /// URL of the generated avatar image
        /// </param>
        /// <param name="revisedPrompt">
        /// The prompt as revised by the model
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GenerateAvatarResponse(
            string url,
            string? revisedPrompt)
        {
            this.Url = url ?? throw new global::System.ArgumentNullException(nameof(url));
            this.RevisedPrompt = revisedPrompt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateAvatarResponse" /> class.
        /// </summary>
        public GenerateAvatarResponse()
        {
        }
    }
}