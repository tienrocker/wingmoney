using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;
using WingMoney.Auth;
using System.Net;
using System.Net.Http.Headers;
using WingMoney.Bill;
using System.IO;
using WingMoney.User;
using WingMoney.Send;

namespace WingMoney
{
    public class WingPayment
    {

        private static WingPayment _instance;
        public static WingPayment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WingPayment();
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; // strict ssl on IP
                }
                return _instance;
            }
        }

        private Auth.TokenResponse _token = null;
        public TokenResponse GetToken()
        {
            if (_token != null && _token.ExpiresTime <= Helper.UnixTime.UnixTimeStamp() - 10) _token = null; // expire after 10 sec
            try
            {
                if (_token == null)
                {
                    HttpClient _client = new HttpClient();
                    StringContent content = new StringContent((new TokenRequest()).ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
                    HttpResponseMessage response = _client.PostAsync(WingSettings.url_callback + WingSettings.url_oauth_token, content).Result;
                    string resultJSON = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        _token = JsonConvert.DeserializeObject<TokenResponse>(resultJSON);
                        if (_token.ExpiresIn != 0) _token.ExpiresTime = Helper.UnixTime.UnixTimeStamp() + _token.ExpiresIn;
                        return _token;
                    }
                    catch (Exception ex)
                    {
                        _token = null;
                        Console.WriteLine(ex.Message + " - " + resultJSON);
                    }
                }
            }
            catch (Exception e)
            {
                _token = null;
                Console.WriteLine(e);
            }
            return _token;
        }

        public Bill.ValidateResponse BillPaymentValidate(string wing_account, string biller_code, string consumer_id, string amount, string sercurity_code)
        {
            try
            {
                var ltoken = GetToken();
                if (ltoken == null) { Console.WriteLine("Empty Token"); return null; }

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WingSettings.url_callback + WingSettings.url_billpayments_validate);
                httpWebRequest.Headers.Add("Authorization", String.Format("Bearer {0}", ltoken.AccessToken));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    ValidationRequest data = new ValidationRequest() { WingAccount = wing_account, BillerCode = biller_code, ConsumerId = consumer_id, Amount = amount, SecurityCode = sercurity_code };
                    string content = JsonConvert.SerializeObject(data);
                    streamWriter.Write(content);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultJSON = streamReader.ReadToEnd();
                    Bill.ValidateResponse validate = JsonConvert.DeserializeObject<Bill.ValidateResponse>(resultJSON);
                    return validate;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public Bill.CommitResponse BillPaymentCommit()
        {
            try
            {
                var ltoken = GetToken();
                if (ltoken == null) { Console.WriteLine("Empty Token"); return null; }

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WingSettings.url_callback + WingSettings.url_billpayments_commit);
                httpWebRequest.Headers.Add("Authorization", String.Format("Bearer {0}", ltoken.AccessToken));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write("{}"); }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultJSON = streamReader.ReadToEnd();
                    Bill.CommitResponse response = JsonConvert.DeserializeObject<Bill.CommitResponse>(resultJSON);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public CurrencyResponse CurrencyResponse(string wing_account)
        {
            try
            {
                var ltoken = GetToken();
                if (ltoken == null) { Console.WriteLine("Empty Token"); return null; }

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WingSettings.url_callback + String.Format(WingSettings.url_user_currency, wing_account));
                httpWebRequest.Headers.Add("Authorization", String.Format("Bearer {0}", ltoken.AccessToken));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultJSON = streamReader.ReadToEnd();
                    User.CurrencyResponse response = JsonConvert.DeserializeObject<User.CurrencyResponse>(resultJSON);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        /// <summary>
        /// {"balance":"12004575.3","wallet_currency":"KHR","account_name":null,"wing_account":"00733335","error_code":null,"message":null}
        /// </summary>
        /// <returns></returns>
        public BalanceResponse BalanceResponse()
        {
            try
            {
                var ltoken = GetToken();
                if (ltoken == null) { Console.WriteLine("Empty Token"); return null; }

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WingSettings.url_callback + WingSettings.url_user_balance);
                httpWebRequest.Headers.Add("Authorization", String.Format("Bearer {0}", ltoken.AccessToken));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write("{}"); }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultJSON = streamReader.ReadToEnd();
                    User.BalanceResponse response = JsonConvert.DeserializeObject<User.BalanceResponse>(resultJSON);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public MoneyResponse SendMoney(string wing_account)
        {
            throw new NotImplementedException();
        }
    }
}
