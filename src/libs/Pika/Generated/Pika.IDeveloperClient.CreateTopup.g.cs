#nullable enable

namespace Pika
{
    public partial interface IDeveloperClient
    {
        /// <summary>
        /// Create a top-up checkout session<br/>
        /// Initiates a credit purchase by creating a checkout session for the specified product.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.TopupResponse> CreateTopupAsync(

            global::Pika.TopupRequest request,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a top-up checkout session<br/>
        /// Initiates a credit purchase by creating a checkout session for the specified product.
        /// </summary>
        /// <param name="productId">
        /// The ID of the top-up product to purchase
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.TopupResponse> CreateTopupAsync(
            string productId,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}