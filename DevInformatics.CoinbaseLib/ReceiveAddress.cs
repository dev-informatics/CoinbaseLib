using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DevInformatics.CoinbaseLib
{
    [DataContract]
    public class ReceiveAddress : ICoinbaseRequestable
    {
        public string UrlParameters
        {
            get { return string.Empty; }
        }

        public string ApiEndPoint
        {
            get { return "account/receive_address"; }
        }

        public bool Success { get; set; }

        public string Address { get; set; }

        [DataMember(Name="callback_url")]
        public string CallbackUrl { get; set; }

        public override string ToString()
        {
            return string.Format("Success={0} | Address={1} | CallbackUrl={2}", this.Success, this.Address, this.CallbackUrl);
        }       
    }
}
