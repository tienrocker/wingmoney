using Newtonsoft.Json;

namespace WingMoney.Bill
{
    /// <summary>
    /// {
    ///     "wing_account" : "00004455",
    ///     "biller_code" : "7019",
    ///     "consumer_id" : "1415910",
    ///     "amount":5,
    ///     "security_code" : "274457"
    /// }
    /// </summary>
    public class ValidationRequest
    {
        /// <summary>
        /// Customer’s wing account (Payer)
        /// </summary>
        [JsonProperty(PropertyName = "wing_account")]
        public string WingAccount { get; set; }

        /// <summary>
        /// Biller Code of Company (Payee)
        /// </summary>
        [JsonProperty(PropertyName = "biller_code")]
        public string BillerCode { get; set; }

        /// <summary>
        /// Unique Biller ID (invoice#, outlet ID, ...)
        /// </summary>
        [JsonProperty(PropertyName = "consumer_id")]
        public string ConsumerId { get; set; }

        /// <summary>
        /// Amount to be paid (USD or KHR base on biller’s account currency)
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 6-digits security code of the customer’s wing account
        /// </summary>
        [JsonProperty(PropertyName = "security_code")]
        public string SecurityCode { get; set; }
    }
}
