
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class CloneVoiceRequest
    {
        /// <summary>
        /// Audio sample for voice cloning (binary upload)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("audio")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required byte[] Audio { get; set; }

        /// <summary>
        /// Audio sample for voice cloning (binary upload)
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("audioname")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Audioname { get; set; }

        /// <summary>
        /// Name for the cloned voice
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// Whether to apply noise reduction to the audio sample<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("noise_reduction")]
        public bool? NoiseReduction { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CloneVoiceRequest" /> class.
        /// </summary>
        /// <param name="audio">
        /// Audio sample for voice cloning (binary upload)
        /// </param>
        /// <param name="audioname">
        /// Audio sample for voice cloning (binary upload)
        /// </param>
        /// <param name="name">
        /// Name for the cloned voice
        /// </param>
        /// <param name="noiseReduction">
        /// Whether to apply noise reduction to the audio sample<br/>
        /// Default Value: false
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public CloneVoiceRequest(
            byte[] audio,
            string audioname,
            string name,
            bool? noiseReduction)
        {
            this.Audio = audio ?? throw new global::System.ArgumentNullException(nameof(audio));
            this.Audioname = audioname ?? throw new global::System.ArgumentNullException(nameof(audioname));
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.NoiseReduction = noiseReduction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloneVoiceRequest" /> class.
        /// </summary>
        public CloneVoiceRequest()
        {
        }
    }
}