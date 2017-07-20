using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.Bill
{
    /// <summary>
    /// {
    ///     "amount " : "KHR 10,000",
    ///     "fee" : "0",
    ///     "total" : "USD 2.46",
    ///     "consumer_id" : "1415910",
    ///     "consumer_name" : "John Doe",
    ///     "exchange_rate" : "USD 1.00 = KHR 4,046",
    ///     "biller_name": "ABC Co LTD"
    /// }
    /// </summary>
    public class ValidateResponse : ErrorResponse
    {

        /// <summary>
        /// Paid amount
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Transferred amount
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        /// <summary>
        /// Payment fee
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string Fee { get; set; }

        /// <summary>
        /// Unique Biller ID (invoice#, outlet ID, ...)
        /// </summary>
        [JsonProperty(PropertyName = "consumer_id")]
        public string ConsumerId { get; set; }

        /// <summary>
        /// Name of the consumer of the invoice or outlet ID (only display if have consumer name from compnany system)
        /// </summary>
        [JsonProperty(PropertyName = "consumer_name")]
        public string ConsumerName { get; set; }

        /// <summary>
        /// Name of the Company
        /// </summary>
        [JsonProperty(PropertyName = "biller_name")]
        public string BillerName { get; set; }

        /// <summary>
        /// Exchange rate (optional, it display only for cross currency transaction)
        /// </summary>
        [JsonProperty(PropertyName = "exchange_rate")]
        public string ExchangeRate { get; set; }

    }
}
