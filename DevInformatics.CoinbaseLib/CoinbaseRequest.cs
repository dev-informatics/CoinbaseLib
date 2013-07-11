using DevInformatics.CoinbaseLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DevInformatics.CoinbaseLib
{
    public class CoinbaseRequest<T> where T : ICoinbaseRequestable, new()
    {
        public CoinbaseAccount CoinbaseAccount { get; set; }

        public CoinbaseRequest(CoinbaseAccount coinbaseAccount)
        {
            this.CoinbaseAccount = coinbaseAccount;
        }

        public T Request(T CEntity)
        {
            try
            {
                var httpWebRequest = HttpWebRequest.CreateHttp(this.CoinbaseAccount.ConstructRequestUrl(CEntity.ApiEndPoint) + CEntity.UrlParameters);

                var response = string.Empty;

                using(var streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }

                var serializer = new JavaScriptSerializer();
                CEntity = serializer.Deserialize<T>(response);

                return CEntity;
            } // try
            catch(Exception e)
            {
                throw e;
            }
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
    }
}
