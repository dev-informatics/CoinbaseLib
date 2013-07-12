using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    public class TransactionDetails
    {
        public string Id { get; set; }
        public DateTime Created_At { get; set; }
        public CoinbaseAmount Amount { get; set; }
        public bool Request { get; set; }
        public string Status { get; set; }
        public CoinbaseUser Sender { get; set; }
        public CoinbaseUser Recipient { get; set; }
    }
}
