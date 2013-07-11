using DevInformatics.CoinbaseLib.Model;
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

        public string ConstructRequestUrl(string requestUrl)
        {
            return string.Format("{0}{1}?api_key={2}", _url, requestUrl, ApiKey);
        }

        public AccountBalance GetAccountBalance()
        {
            var accountBalance = new CoinbaseRequest<AccountBalance>(this).Request();
            return accountBalance;
        }

        public ReceiveAddress GetReceiveAddress()
        {
            var receiveAddress = new CoinbaseRequest<ReceiveAddress>(this).Request();
            return receiveAddress;
        }

        public BuyPrice GetBuyPrice(double quantity)
        {
            var buyPrice = new BuyPrice() { Quantity = quantity };
            buyPrice = new CoinbaseRequest<BuyPrice>(this).Request(buyPrice);
            return buyPrice;
        }

        public SellPrice GetSellPrice(double quantity)
        {
            var sellPrice = new SellPrice() { Quantity = quantity };
            sellPrice = new CoinbaseRequest<SellPrice>(this).Request(sellPrice);
            return sellPrice;
        }
    }
}
