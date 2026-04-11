#nullable enable

namespace Pika
{
    public partial interface IDeveloperClient
    {
        /// <summary>
        /// List available top-up products<br/>
        /// Returns a list of credit top-up products available for purchase.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.TopupProductsResponse> GetTopupProductsAsync(
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}