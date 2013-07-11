using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DevInformatics.CoinbaseLib.Model
{
    public class AccountBalance : ICoinbaseRequestable
    {
        public string UrlParameters
        {
            get { return string.Empty; }
        }

        public string ApiEndPoint
        {
            get { return "account/balance"; }
        }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public AccountBalance()
        {

        }
        public override string ToString()
        {
            return string.Format("Amount={0} | Currency={1}", this.Amount, this.Currency);
        }       
    }
}
