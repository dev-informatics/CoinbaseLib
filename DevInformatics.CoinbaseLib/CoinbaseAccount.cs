using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib
{
    public class CoinbaseAccount 
    {
        private const string version = "v1/";

        public enum ResourceRequest
        {
            AccountBalance,
            ReceiveAddress
        }

        private const string _url = "https://coinbase.com/api/" + version;

        public string ApiKey { get; set; }

        public CoinbaseAccount(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ConstructRequest(string requestUrl)
        {
            return string.Format("{0}{1}?api_key={2}", _url, requestUrl, ApiKey);
        }
    }
}
