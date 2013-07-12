using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevInformatics.CoinbaseLib.Model
{
    public class CoinbaseFee
    {
        public int Cents { get; set; }
        public string Currency_Iso { get; set; }
    }
}
