
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class TopupResponse
    {
        /// <summary>
        /// URL to complete the checkout
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("checkout_url")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string CheckoutUrl { get; set; }

        /// <summary>
        /// Checkout session identifier
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("session_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SessionId { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupResponse" /> class.
        /// </summary>
        /// <param name="checkoutUrl">
        /// URL to complete the checkout
        /// </param>
        /// <param name="sessionId">
        /// Checkout session identifier
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TopupResponse(
            string checkoutUrl,
            string sessionId)
        {
            this.CheckoutUrl = checkoutUrl ?? throw new global::System.ArgumentNullException(nameof(checkoutUrl));
            this.SessionId = sessionId ?? throw new global::System.ArgumentNullException(nameof(sessionId));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupResponse" /> class.
        /// </summary>
        public TopupResponse()
        {
        }
    }
}