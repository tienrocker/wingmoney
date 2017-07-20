using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.User
{
    /// <summary>
    /// {
    ///     "wing_account": "00001243",
    ///     "wallet_currency": "USD",
    ///     "account_name": "John Doe"
    /// }
    /// 
    /// {
    ///     "wing_account": "xxx",
    ///     "wallet_currency": "KHR",
    ///     "account_name": "xxx xxx"
    /// }
    /// </summary>
    public class CurrencyResponse : ErrorResponse
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
