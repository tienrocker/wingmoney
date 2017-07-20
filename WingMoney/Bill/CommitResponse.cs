using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.Bill
{
    /// <summary>
    /// {
    ///     "biller_name ": "ABC Co LTD",
    ///     "biller_code": "7500",
    ///     "consumer_id": "1415910",
    ///     "amount": "USD 5.00",
    ///     "total ": "USD 5.00",
    ///     "exchange_rate" : "USD 1.00 = KHR 4,046",
    ///     "fee": "USD 0.00",
    ///     "transaction_id": "INT000001"
    /// }
    /// 
    /// {"biller_name":null,"biller_code":null,"amount":null,"total":null,"consumer_id":null,"fee":null,"exchange_rate":null,"transaction_id":null,"error_code":"E0204","message":"Balance is insufficient. Please cash in your account at nearest Wing outlets"}
    /// 
    /// </summary>
    public class CommitResponse : ErrorResponse
    {
        /// <summary>
        /// Name of the Company
        /// </summary>
        [JsonProperty(PropertyName = "biller_name")]
        public string BillerName { get; set; }

        /// <summary>
        /// Unique Identifier of Company
        /// </summary>
        [JsonProperty(PropertyName = "biller_code")]
        public string BillerCode { get; set; }

        /// <summary>
        /// Paid amount
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Total transferred amount
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        /// <summary>
        /// Unique Biller ID (invoice#, outlet ID, ...)
        /// </summary>
        [JsonProperty(PropertyName = "consumer_id")]
        public string ConsumerId { get; set; }

        /// <summary>
        /// Payment fee
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string Fee { get; set; }

        /// <summary>
        /// Exchange rate (optional, it display only for cross currency transaction)
        /// </summary>
        [JsonProperty(PropertyName = "exchange_rate")]
        public string ExchangeRate { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }

    }
}
