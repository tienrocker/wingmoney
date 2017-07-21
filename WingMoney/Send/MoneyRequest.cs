using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.Send
{
    /// <summary>
    /// {
    ///     "currency": "USD",
    ///     "amount": 5,
    ///     "receiver_account": "00009911"
    /// }
    /// </summary>
    public class MoneyRequest
    {

        /// <summary>
        /// KHR or USD (base on Payer’s currency)
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Amount to be transfer
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Receiver’s wing account
        /// </summary>
        [JsonProperty(PropertyName = "receiver_account")]
        public string ReceiverAccount { get; set; }

    }
}
