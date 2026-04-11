#nullable enable

namespace Pika
{
    public partial interface ISessionsClient
    {
        /// <summary>
        /// End a meeting session<br/>
        /// Terminates an active meeting session, causing the avatar bot to leave the call.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Pika.DeleteSessionResponse> DeleteSessionAsync(
            string sessionId,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}