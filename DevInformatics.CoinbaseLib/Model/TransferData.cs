using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    public class TransferData
    {
        public string _Type { get; set; }

        public string Code { get; set; }

        public DateTime Created_At { get; set; }

        public CoinbaseFees Fees { get; set; }

        public DateTime Payout_Date { get; set; }

        public string Transaction_Id { get; set; }

        public string Status { get; set; }

        public CoinbaseAmount Btc { get; set; }

        public CoinbaseAmount SubTotal { get; set; }

        public CoinbaseAmount Total { get; set; }

        public string Description { get; set; }
    }
}
