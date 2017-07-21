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

            do
            {
                Console.WriteLine("Press...");

                while (!Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {

                        case ConsoleKey.D1:
                            // get token
                            Console.WriteLine("token");
                            TokenResponse token = WingPayment.Instance.GetToken();
                            Console.WriteLine(JsonConvert.SerializeObject(token));
                            break;

                        case ConsoleKey.D2:
                            // balance
                            Console.WriteLine("balance");
                            WingMoney.User.BalanceResponse balance = WingPayment.Instance.BalanceResponse();
                            Console.WriteLine(JsonConvert.SerializeObject(balance));
                            break;

                        case ConsoleKey.D3:
                            // get user currency
                            Console.WriteLine("currency");
                            WingMoney.User.CurrencyResponse currency = WingPayment.Instance.CurrencyResponse("00287131");
                            Console.WriteLine(JsonConvert.SerializeObject(currency));
                            break;

                        case ConsoleKey.D4:

                            string sercurity_code = Console.ReadLine();
                            Random rnd = new Random();
                            int card = rnd.Next(1415911);

                            // validate money
                            Console.WriteLine("validate");
                            WingMoney.Bill.ValidateResponse validate = WingPayment.Instance.BillPaymentValidate("00287131", "7019", card.ToString(), "1", sercurity_code);
                            Console.WriteLine(JsonConvert.SerializeObject(validate));
                            break;

                        case ConsoleKey.D5:
                            // commit
                            Console.WriteLine("commit");
                            WingMoney.Bill.CommitResponse commit = WingPayment.Instance.BillPaymentCommit();
                            Console.WriteLine(JsonConvert.SerializeObject(commit));
                            break;

                        case ConsoleKey.D6:
                            // send money
                            Console.WriteLine("send");
                            WingMoney.Send.MoneyResponse send = WingPayment.Instance.SendMoney("00287131", "10");
                            Console.WriteLine(JsonConvert.SerializeObject(send));
                            break;
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
    }
}
