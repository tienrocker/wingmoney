using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingMoney;
using WingMoney.Auth;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // get token
            TokenResponse token = WingPayment.Instance.GetToken();
            Console.WriteLine(JsonConvert.SerializeObject(token));

            // balance
            WingMoney.User.BalanceResponse balance = WingPayment.Instance.BalanceResponse();
            Console.WriteLine(JsonConvert.SerializeObject(balance));

            // get user currency
            WingMoney.User.CurrencyResponse currency = WingPayment.Instance.CurrencyResponse("00383661");
            Console.WriteLine(JsonConvert.SerializeObject(currency));

            // validate money
            WingMoney.Bill.ValidateResponse validate = WingPayment.Instance.BillPaymentValidate("00383661", "7019", "1415910", "5", "893632");
            Console.WriteLine(JsonConvert.SerializeObject(validate));

            // commit
            WingMoney.Bill.CommitResponse commit = WingPayment.Instance.BillPaymentCommit();
            Console.WriteLine(JsonConvert.SerializeObject(commit));

            // send money
            WingMoney.Send.MoneyResponse send = WingPayment.Instance.SendMoney("00383661");
            Console.WriteLine(JsonConvert.SerializeObject(send));

            Console.ReadKey();
        }
    }
}
