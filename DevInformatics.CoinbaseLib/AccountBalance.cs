using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DevInformatics.CoinbaseLib
{
    public class AccountBalance
    {
        private const string ApiUrl = "account/balance";

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public AccountBalance()
        {

        }

        internal AccountBalance(decimal amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public static AccountBalance Request(CoinbaseAccount coinbaseAccount)
        {
            try
            {
                HttpWebRequest webRequest = HttpWebRequest.CreateHttp(coinbaseAccount.ConstructRequest(ApiUrl));

                var response = string.Empty;

                using (StreamReader reader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    response = reader.ReadToEnd();
                } // using

                var serializer = new JavaScriptSerializer();
                var accountBalance = serializer.Deserialize<AccountBalance>(response);

                return accountBalance;
            } // try
            catch(Exception e)
            {
                throw e;
            }
        }

        public override string ToString()
        {
            return string.Format("Amount={0} | Currency={1}", this.Amount, this.Currency);
        }
    }
}
