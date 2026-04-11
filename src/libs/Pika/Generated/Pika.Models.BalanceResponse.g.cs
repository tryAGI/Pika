
#nullable enable

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class BalanceResponse
    {
        /// <summary>
        /// Current credit balance
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("balance")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double Balance { get; set; }

        /// <summary>
        /// Currency code (e.g., "USD")
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("currency")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Currency { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse" /> class.
        /// </summary>
        /// <param name="balance">
        /// Current credit balance
        /// </param>
        /// <param name="currency">
        /// Currency code (e.g., "USD")
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public BalanceResponse(
            double balance,
            string currency)
        {
            this.Balance = balance;
            this.Currency = currency ?? throw new global::System.ArgumentNullException(nameof(currency));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse" /> class.
        /// </summary>
        public BalanceResponse()
        {
        }
    }
}