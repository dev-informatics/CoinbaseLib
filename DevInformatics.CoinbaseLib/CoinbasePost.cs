using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib
{
    public class HttpsCoinbasePost<T> where T : ICoinbasePostable, new()
    {
        public IHttpsCoinbaseAccount CoinbaseAccount { get; set; }

        public HttpsCoinbasePost()
        {

        }

        public HttpsCoinbasePost(IHttpsCoinbaseAccount coinbaseAccount)
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
