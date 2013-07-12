using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    [DataContract]
    public class Transaction
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name="created_at")]
        public DateTime CreateAt { get; set; }
        public Balance Amount { get; set; }
        public bool Request { get; set; }
        public string Status { get; set; }
    }
}
