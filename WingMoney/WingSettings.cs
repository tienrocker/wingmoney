namespace WingMoney
{
    public class WingSettings
    {
        public const string username = "test.partner";
        public const string password = "ba0228f6e48ba7942d79e2b44e6072ee";
        public const string client_id = "third_party";
        public const string client_secret = "16681c9ff419d8ecc7cfe479eb02a7a";

        public const string url_callback = "https://110.74.218.219:8443/RestEngine";

        public const string url_oauth_token = "/oauth/token";

        public const string url_billpayments_validate = "/api/v3/billpayments/validate";
        public const string url_billpayments_commit = "/api/v3/billpayments/commit";

        // 0 is wing_account
        public const string url_user_currency = "/api/v1/user/currency/{0}";

        public const string url_user_balance = "/api/v1/user/info";
    }
}