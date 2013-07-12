using DevInformatics.CoinbaseLib.Interface;
using DevInformatics.CoinbaseLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib
{
    public class HttpsCoinbaseAccount : IHttpsCoinbaseAccount
    {
        private const string version = "v1/";

        private const string _url = "https://coinbase.com/api/" + version;

        public string ApiKey { get; set; }

        public HttpsCoinbaseAccount(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ConstructRequestUrl(string requestUrl)
        {
            return string.Format("{0}{1}?api_key={2}", _url, requestUrl, ApiKey);
        }

        public AccountBalance GetAccountBalance()
        {
            var accountBalance = new HttpsCoinbaseRequest<AccountBalance>(this).Request();
            return accountBalance;
        }

        public ReceiveAddress GetReceiveAddress()
        {
            var receiveAddress = new HttpsCoinbaseRequest<ReceiveAddress>(this).Request();
            return receiveAddress;
        }

        public BuyPrice GetBuyPrice(double quantity)
        {
            var buyPrice = new BuyPrice() { Quantity = quantity };
            buyPrice = new HttpsCoinbaseRequest<BuyPrice>(this).Request(new Dictionary<string, string>()
            {
                { "qty", quantity.ToString() }
            }, ParameterType.QUERYSTRING);
            return buyPrice;
        }

        public SellPrice GetSellPrice(double quantity)
        {
            var sellPrice = new SellPrice() { Quantity = quantity };
            sellPrice = new HttpsCoinbaseRequest<SellPrice>(this).Request(new Dictionary<string, string>()
            {
                { "qty", quantity.ToString() }
            }, ParameterType.QUERYSTRING);
            return sellPrice;
        }

        public TransactionsRequestResponse GetTransactions(int page = 1)
        {
            var transactionsResponse = new HttpsCoinbaseRequest<TransactionsRequestResponse>(this).Request(new Dictionary<string, string>()
                {
                    { "page", page.ToString() }
                }, ParameterType.QUERYSTRING);
            return transactionsResponse;
        }

        public TransactionData GetTransaction(string id)
        {
            var transactionData = new HttpsCoinbaseRequest<TransactionData>(this).Request(new Dictionary<string, string>(){
                { "id", id }
            }, ParameterType.URI);
            return transactionData;
        }
    }
}
