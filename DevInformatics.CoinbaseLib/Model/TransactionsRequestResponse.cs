using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevInformatics.CoinbaseLib.Model
{
    public class TransactionsRequestResponse : ICoinbaseCommunicable
    {
        public CoinbaseUser Current_User { get; set; }
        public CoinbaseAmount Balance { get; set; }       
        public int Total_Count { get; set; }
        public int Num_Pages { get; set; }
        public int Current_Page { get; set; }
        public ICollection<TransactionData> Transactions { get; set; }        
        public string ApiEndPoint
        {
            get { return "transactions"; }
        }
    }
}
