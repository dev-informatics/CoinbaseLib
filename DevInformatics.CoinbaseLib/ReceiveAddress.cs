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
    public class ReceiveAddress
    {
        private const string ApiUrl = "account/receive_address";

        public bool Success { get; set; }

        public string Address { get; set; }

        [DataMember(Name="callback_url")]
        public string CallbackUrl { get; set; }

        public static ReceiveAddress Request(CoinbaseAccount coinbaseAccount)
        {
            try
            {
                var webRequest = HttpWebRequest.CreateHttp(coinbaseAccount.ConstructRequest(ApiUrl));

                var response = string.Empty;

                using(var streamReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                } // using

                var serializer = new JavaScriptSerializer();
                var receiveAddress = serializer.Deserialize<ReceiveAddress>(response);

                return receiveAddress;
            }
            catch(Exception e)
            {
                throw e;
            } // catch
        }

        public override string ToString()
        {
            return string.Format("Success={0} | Address={1} | CallbackUrl={2}", this.Success, this.Address, this.CallbackUrl);
        }
    }
}
