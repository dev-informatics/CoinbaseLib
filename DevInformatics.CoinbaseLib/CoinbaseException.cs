using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib
{
    public class CoinbaseException : ApplicationException
    {
        public CoinbaseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
