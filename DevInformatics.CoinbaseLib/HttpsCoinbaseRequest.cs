using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DevInformatics.CoinbaseLib
{
    public class HttpsCoinbaseRequest<T> : ICoinbaseRequest<T> where T : ICoinbaseCommunicable, new() 
    {
        public IHttpsCoinbaseAccount CoinbaseAccount { get; set; }

        public HttpsCoinbaseRequest(IHttpsCoinbaseAccount coinbaseAccount)
        {
            this.CoinbaseAccount = coinbaseAccount;
        }            

        public T Request()
        {
            try
            {
                var cEntity = new T();

                var httpWebRequest = HttpWebRequest.CreateHttp(this.CoinbaseAccount.ConstructRequestUrl(cEntity.ApiEndPoint));

                var response = string.Empty;

                using (var streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                var serializer = new JavaScriptSerializer();
                cEntity = serializer.Deserialize<T>(response);

                return cEntity;
            } // try
            catch (Exception e)
            {
                throw e;
            }
        }


        public T Request(IDictionary<string, string> parameters, ParameterType parameterType)
        {
            try
            {
                var cEntity = new T();

                var getParams = new StringBuilder();
                var apiEndpont = cEntity.ApiEndPoint;

                if (parameterType == ParameterType.QUERYSTRING)
                {
                    foreach (string key in parameters.Keys)
                    {
                        getParams.Append("&" + key + "=" + parameters[key]);
                    } // foreach
                } // if
                else
                {
                    foreach (string key in parameters.Keys)
                    {
                        apiEndpont += "/" + parameters[key];
                    } // foreach
                } // else

                var httpWebRequest = HttpWebRequest.CreateHttp(this.CoinbaseAccount.ConstructRequestUrl(apiEndpont) + getParams);

                var response = string.Empty;

                using (var streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                var serializer = new JavaScriptSerializer();
                cEntity = serializer.Deserialize<T>(response);

                return cEntity;
            } // try
            catch (Exception e)
            {
                throw e;
            } new NotImplementedException();
        }
    }
}
