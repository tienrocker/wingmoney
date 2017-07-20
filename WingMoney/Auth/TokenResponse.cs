using Newtonsoft.Json;
using WingMoney.Error;

namespace WingMoney.Auth
{
    /// <summary>
    /// 
    /// success:
    /// {
    ///     "access_token": "22cb0d50-5bb9-463d-8c4a-8ddd680f553f",
    ///     "token_type": "bearer",
    ///     "expires_in": 119
    /// }
    /// 
    /// error:
    /// {
    ///     "error": "invalid_client",
    ///     "error_description": "Bad client credentials"
    /// }
    /// </summary>
    public class TokenResponse
    {

        /// <summary>
        /// Access token that acts as a session ID that the application uses
        /// for making requests.This token should be protected as though it
        /// were user credentials.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Token expiration time (in second)
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int? ExpiresIn { get; set; }

        /// <summary>
        /// Token type
        /// </summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Fake UnixTime
        /// </summary>
        [JsonProperty(PropertyName = "expires_time")]
        public int? ExpiresTime { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

    }
}
