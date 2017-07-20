using Newtonsoft.Json;

namespace WingMoney.Error
{
    /// <summary>
    /// {"error_code":"00335","message":"Security Code & Wing Account mismatch."}
    /// </summary>
    public class ErrorResponse
    {

        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty(PropertyName = "error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}