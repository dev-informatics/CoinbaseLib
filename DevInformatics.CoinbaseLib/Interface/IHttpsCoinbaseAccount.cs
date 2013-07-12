﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInformatics.CoinbaseLib.Interface
{
    public interface IHttpsCoinbaseAccount : ICoinbaseAccount
    {
        string ConstructRequestUrl(string requestUrl);
    }
}
