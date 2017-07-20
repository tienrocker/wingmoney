using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.User
{
    /// <summary>
    /// {
    ///     "balance": "100.50",
    ///     "wallet_currency": "USD",
    ///     "company_name": "ABC Ltd",
    ///     "wing_account": "00900012"
    /// }
    /// </summary>
    public class BalanceResponse : ErrorResponse
    {

        /// <summary>
        /// Balance Remaining
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }

        /// <summary>
        /// Wallet currency (KHR / USD)
        /// </summary>
        [JsonProperty(PropertyName = "wallet_currency")]
        public string WalletCurrency { get; set; }

        /// <summary>
        /// Name of the company/organization
        /// </summary>
        [JsonProperty(PropertyName = "account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// Prefund account number at Wing
        /// </summary>
        [JsonProperty(PropertyName = "wing_account")]
        public string WingAccount { get; set; }

    }
}
