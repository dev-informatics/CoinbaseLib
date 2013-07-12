using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DevInformatics.CoinbaseLib.Model
{    
    [DataContract]
    public class BuyPrice : ICoinbaseCommunicable
    {
        public string ApiEndPoint { get { return "prices/buy"; } }  
        public decimal Amount { get; set; }
        public string Currency { get; set; }               
        public override string ToString()
        {
            return string.Format("Amount:{0} | Currency:{1}", Amount, Currency);
        }       
    }
}
