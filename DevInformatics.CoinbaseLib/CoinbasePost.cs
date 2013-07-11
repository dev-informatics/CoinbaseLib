using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib
{
    public class CoinbasePost<T> where T : ICoinbasePostable, new()
    {
        public CoinbaseAccount CoinbaseAccount { get; set; }

        public CoinbasePost()
        {

        }

        public CoinbasePost(CoinbaseAccount coinbaseAccount)
        {
            CoinbaseAccount = coinbaseAccount;
        }

        public T Post(T CEntity)
        {
            return default(T);
        }

        public T Post()
        {
            return default(T);
        }
    }
}
