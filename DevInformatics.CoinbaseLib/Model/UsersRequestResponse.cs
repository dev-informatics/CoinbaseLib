using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Model
{
    public class UsersRequestResponse : ICoinbaseCommunicable
    {
        public ICollection<UserDetails> Users { get; set; }

        public string ApiEndPoint
        {
            get { return "users"; }
        }
    }
}
