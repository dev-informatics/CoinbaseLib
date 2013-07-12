using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    public class CoinbaseUser
    {       
        public string Id { get; set; } 
        public string Email { get; set; }
        public string Name { get; set; }

        public string Time_Zone { get; set; }

        public string Native_Currency { get; set; }
        public CoinbaseAmount Balance { get; set; }

        public int Buy_Level { get; set; }

        public int Sell_Level { get; set; }

        public CoinbaseAmount Buy_Limit { get; set; }

        public CoinbaseAmount Sell_Limit { get; set; }
    }
}
