
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class TopupProductsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("products")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<global::Pika.TopupProduct> Products { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupProductsResponse" /> class.
        /// </summary>
        /// <param name="products"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TopupProductsResponse(
            global::System.Collections.Generic.IList<global::Pika.TopupProduct> products)
        {
            this.Products = products ?? throw new global::System.ArgumentNullException(nameof(products));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupProductsResponse" /> class.
        /// </summary>
        public TopupProductsResponse()
        {
        }
    }
}