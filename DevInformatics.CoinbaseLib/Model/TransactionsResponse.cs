using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    [DataContract]
    public class TransactionsResponse
    {
        public Balance Balance { get; set; }

        [DataMember(Name="total_count")]
        public int TotalCount { get; set; }

        [DataMember(Name="num_pages")]
        public int NumPages { get; set; }

        [DataMember(Name="current_page")]
        public int CurrentPage { get; set; }
    }
}
