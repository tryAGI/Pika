
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class TopupProduct
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Id { get; set; }

        /// <summary>
        /// Product display name
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// Number of credits included
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("credits")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double Credits { get; set; }

        /// <summary>
        /// Price in cents
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("price_cents")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int PriceCents { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupProduct" /> class.
        /// </summary>
        /// <param name="id">
        /// Product identifier
        /// </param>
        /// <param name="name">
        /// Product display name
        /// </param>
        /// <param name="credits">
        /// Number of credits included
        /// </param>
        /// <param name="priceCents">
        /// Price in cents
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TopupProduct(
            string id,
            string name,
            double credits,
            int priceCents)
        {
            this.Id = id ?? throw new global::System.ArgumentNullException(nameof(id));
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Credits = credits;
            this.PriceCents = priceCents;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopupProduct" /> class.
        /// </summary>
        public TopupProduct()
        {
        }
    }
}