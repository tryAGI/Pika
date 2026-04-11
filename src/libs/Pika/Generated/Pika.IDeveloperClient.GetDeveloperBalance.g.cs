#nullable enable

namespace Pika
{
    public partial interface IDeveloperClient
    {
        /// <summary>
        /// Get developer account balance<br/>
        /// Returns the current credit balance and currency for the authenticated developer account.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.BalanceResponse> GetDeveloperBalanceAsync(
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}