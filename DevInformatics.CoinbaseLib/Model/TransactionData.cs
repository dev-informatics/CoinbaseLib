using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    public class TransactionData : ICoinbaseCommunicable
    {
        public TransactionDetails Transaction { get; set; }
        public string ApiEndPoint
        {
            get { return "transactions"; }
        }
    }
}
