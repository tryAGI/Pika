#nullable enable

namespace Pika
{
    public partial interface IVoiceClient
    {
        /// <summary>
        /// Clone a voice from audio<br/>
        /// Creates a cloned voice from an audio sample. The cloned voice can be used<br/>
        /// for avatar speech synthesis in meeting sessions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.CloneVoiceResponse> CloneVoiceAsync(

            global::Pika.CloneVoiceRequest request,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Clone a voice from audio<br/>
        /// Creates a cloned voice from an audio sample. The cloned voice can be used<br/>
        /// for avatar speech synthesis in meeting sessions.
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
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.CloneVoiceResponse> CloneVoiceAsync(
            byte[] audio,
            string audioname,
            string name,
            bool? noiseReduction = default,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}