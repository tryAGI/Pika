
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class GenerateAvatarRequest
    {
        /// <summary>
        /// Text description for avatar generation
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// Model to use for generation<br/>
        /// Default Value: gpt-image-1-mini
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateAvatarRequest" /> class.
        /// </summary>
        /// <param name="prompt">
        /// Text description for avatar generation
        /// </param>
        /// <param name="model">
        /// Model to use for generation<br/>
        /// Default Value: gpt-image-1-mini
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GenerateAvatarRequest(
            string? prompt,
            string? model)
        {
            this.Prompt = prompt;
            this.Model = model;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateAvatarRequest" /> class.
        /// </summary>
        public GenerateAvatarRequest()
        {
        }
    }
}