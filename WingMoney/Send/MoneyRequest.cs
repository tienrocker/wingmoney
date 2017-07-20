using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.Send
{
    /// <summary>
    /// {
    ///     "amount":30,
    ///     "currency": "USD",
    ///     "receiver_account" : "00499973"
    /// }
    /// </summary>
    public class MoneyRequest
    {

        /// <summary>
        /// Receiver Wing Account number
        /// </summary>
        [JsonProperty(PropertyName = "wing_account")]
        public string WingAccount { get; set; }

        /// <summary>
        /// Wallet currency (KHR / USD)
        /// </summary>
        [JsonProperty(PropertyName = "wallet_currency")]
        public string WalletCurrency { get; set; }

        /// <summary>
        /// Wing Account name
        /// </summary>
        [JsonProperty(PropertyName = "account_name")]
        public string AccountName { get; set; }

    }
}
