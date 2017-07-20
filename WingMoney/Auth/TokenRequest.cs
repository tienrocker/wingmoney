using Newtonsoft.Json;

namespace WingMoney.Bill
{
    public class TokenRequest
    {
        /// <summary>
        /// Customer’s wing account (Payer)
        /// </summary>
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get { return "password"; } }

        /// <summary>
        /// Biller Code of Company (Payee)
        /// </summary>
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get { return "trust"; } }

        /// <summary>
        /// Unique Biller ID (invoice#, outlet ID, ...)
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get { return WingSettings.username; } }

        /// <summary>
        /// Amount to be paid (USD or KHR base on biller’s account currency)
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get { return WingSettings.password; } }

        /// <summary>
        /// 6-digits security code of the customer’s wing account
        /// </summary>
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get { return WingSettings.client_id; } }

        /// <summary>
        /// 6-digits security code of the customer’s wing account
        /// </summary>
        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get { return WingSettings.client_secret; } }

        /// <summary>
        /// Convert to query string
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return string.Format("username={0}&password={1}&client_id={2}&client_secret={3}&grant_type={4}&scope={5}", Username, Password, ClientId, ClientSecret, GrantType, Scope);
        }
    }
}
