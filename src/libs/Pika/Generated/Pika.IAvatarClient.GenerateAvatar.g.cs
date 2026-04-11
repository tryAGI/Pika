#nullable enable

namespace Pika
{
    public partial interface IAvatarClient
    {
        /// <summary>
        /// Generate an avatar image<br/>
        /// Generates an AI avatar image from a text prompt using a specified model.<br/>
        /// The generated image can be used as the avatar appearance in meeting sessions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.GenerateAvatarResponse> GenerateAvatarAsync(

            global::Pika.GenerateAvatarRequest request,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Generate an avatar image<br/>
        /// Generates an AI avatar image from a text prompt using a specified model.<br/>
        /// The generated image can be used as the avatar appearance in meeting sessions.
        /// </summary>
        /// <param name="prompt">
        /// Text description for avatar generation
        /// </param>
        /// <param name="model">
        /// Model to use for generation<br/>
        /// Default Value: gpt-image-1-mini
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.GenerateAvatarResponse> GenerateAvatarAsync(
            string? prompt = default,
            string? model = default,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}