
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class TopupRequest
    {
        /// <summary>
        /// The ID of the top-up product to purchase
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("product_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string ProductId { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupRequest" /> class.
        /// </summary>
        /// <param name="productId">
        /// The ID of the top-up product to purchase
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TopupRequest(
            string productId)
        {
            this.ProductId = productId ?? throw new global::System.ArgumentNullException(nameof(productId));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupRequest" /> class.
        /// </summary>
        public TopupRequest()
        {
        }
    }
}