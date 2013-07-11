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
    public class BuyPrice : ICoinbaseRequestable
    {
        public string ApiEndPoint
        {
            get { return "prices/buy"; }
        }

        private string urlParameters = string.Empty;
        public string UrlParameters
        {
            get { return "&qty=" + Quantity.ToString(); }
        }
   
        public decimal Amount { get; set; }
        public string Currency { get; set; }   
     
        [DataMember(IsRequired=false)]
        public double Quantity { get; set; }
        
        public BuyPrice()
        {

        }

        public override string ToString()
        {
            return string.Format("Quantity:{0} | Amount:{1} | Currency:{2}", Quantity, Amount, Currency);
        }

        
    }
}
