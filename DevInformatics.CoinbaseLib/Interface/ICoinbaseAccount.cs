using DevInformatics.CoinbaseLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Interface
{
    public interface ICoinbaseAccount
    {
        AccountBalance GetAccountBalance();
        ReceiveAddress GetReceiveAddress();
        BuyPrice GetBuyPrice(double quantity);
        SellPrice GetSellPrice(double quantity);
        TransactionsRequestResponse GetTransactions(int page = 1);
    }
}
