using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.Send
{
    /// <summary>
    /// {
    ///     "currency" : "USD",
    ///     "amount" : " 10.00USD",
    ///     "fee" : " 0.25USD",
    ///     "total" : "10.25USD",
    ///     "exchange_rate" : "",
    ///     "transaction_id" : " EAB000001",
    ///     "balance" : "100.00USD",
    ///     "account_name" : "Sok Dara"
    /// }
    /// </summary>
    public class MoneyResponse : ErrorResponse
    {

        /// <summary>
        /// Currency (KHR / USD)
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Fee charge (optional, if there is no fee it won’t display)
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string Fee { get; set; }

        /// <summary>
        /// Total amount (Amount+Fee)
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        /// <summary>
        /// Exchange rate (optional, display only for cross currency transaction)
        /// </summary>
        [JsonProperty(PropertyName = "exchange_rate")]
        public string ExchangeRate { get; set; }

        /// <summary>
        /// Transaction Id
        /// </summary>
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Sender’s remaining balance
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }

        /// <summary>
        /// Name of the receiver account
        /// </summary>
        [JsonProperty(PropertyName = "account_name")]
        public string AccountName { get; set; }

    }
}
