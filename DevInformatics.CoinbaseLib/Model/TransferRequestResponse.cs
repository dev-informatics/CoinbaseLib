using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    public class TransferRequestResponse : ICoinbaseCommunicable
    {
        public ICollection<TransferDetails> Transfers { get; set; }
        public int Total_Count { get; set; }
        public int Num_Pages { get; set; }
        public int Current_Page { get; set; }

        public string ApiEndPoint
        {
            get { return "transfers"; }
        }
    }
}
