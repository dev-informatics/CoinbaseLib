using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    [DataContract]
    public class CoinbaseUser
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name="email")]
        public string Email { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}
