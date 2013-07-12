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
            var buyPrice = new HttpsCoinbaseRequest<BuyPrice>(this).Request(new Dictionary<string, string>()
            {
                { "qty", quantity.ToString() }
            }, ParameterType.QUERYSTRING);
            return buyPrice;
        }

        public SellPrice GetSellPrice(double quantity)
        {
            var sellPrice = new HttpsCoinbaseRequest<SellPrice>(this).Request(new Dictionary<string, string>()
            {
                { "qty", quantity.ToString() }
            }, ParameterType.QUERYSTRING);
            return sellPrice;
        }

        /// <summary>
        /// Retrieves TransactionData in a paginated fashion. Note, 30 transactions are listed per page. This
        /// value is hardcoded at Coinbase. ref: https://coinbase.com/api/doc/transactions/index.html
        /// </summary>
        /// <param name="page">The Page number to retrieve.</param>
        /// <returns>A TransactionRequestResponse that contains a list of TransactionDetails.</returns>
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

        public TransferRequestResponse GetTransfers(int page = 1, int limit = 10)
        {
            // Coinbase API docs state that 1000 is the highest limit definable.
            // ref: https://coinbase.com/api/doc/transfers/index.html
            if(limit > 1000)
            {
                limit = 1000;
            } // if

            var transferRequestResponse = new HttpsCoinbaseRequest<TransferRequestResponse>(this).Request(new Dictionary<string, string>(){
                { "page", page.ToString() },
                { "limit", limit.ToString() }
            }, ParameterType.QUERYSTRING);
            return transferRequestResponse;
        }

        public CoinbaseUser GetUser()
        {
            var response = new HttpsCoinbaseRequest<UsersRequestResponse>(this).Request();
            if(response.Users.Count >= 1)
            {
                return response.Users.First().User;
            } // if
            throw new CoinbaseException("The Coinbase User Account could not be loaded.", null);
        }
    }
}
