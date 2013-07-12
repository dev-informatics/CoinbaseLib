using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Interface
{
    public enum ParameterType
    {
        URI,
        QUERYSTRING
    }

    public interface ICoinbaseRequest<T>
    {
        T Request();

        T Request(IDictionary<string, string> parameters, ParameterType parameterType);
    }
}
