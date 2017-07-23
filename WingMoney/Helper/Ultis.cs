using System;
using System.Text.RegularExpressions;

namespace WingMoney.Helper
{
    public class Ultis
    {

        public static int UnixTimeStamp()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        // "USD 1,000.2323"
        public static float USDStringToFloat(string usd_string)
        {
            Regex rx = new Regex(@"[0-9,]+\.[0-9]+");
            Match m = rx.Match(usd_string);
            float usd = 0;
            float.TryParse(m.ToString(), out usd);
            return usd;
        }

    }
}
