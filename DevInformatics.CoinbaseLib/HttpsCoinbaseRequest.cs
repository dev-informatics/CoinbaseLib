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
    public class HttpsCoinbaseRequest<T> : ICoinbaseRequest<T> where T : ICoinbaseRequestable, new() 
    {
        public IHttpsCoinbaseAccount CoinbaseAccount { get; set; }

        public HttpsCoinbaseRequest(IHttpsCoinbaseAccount coinbaseAccount)
        {
            this.CoinbaseAccount = coinbaseAccount;
        }

        public T Request(T CEntity)
        {
            try
            {
                X509Certificate certificate;

                using(Stream certStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), @"ca-coinbase.crt"))
                {
                    byte[] cert;
                    cert = new byte[certStream.Length];
                    for(int i = 0; i < certStream.Length; i++)
                    {
                        cert[i] = (byte)certStream.ReadByte();
                    } // for
                    certificate = new X509Certificate();
                    certificate.Import(cert);
                } // using

                var httpWebRequest = HttpWebRequest.CreateHttp(this.CoinbaseAccount.ConstructRequestUrl(CEntity.ApiEndPoint) + CEntity.UrlParameters);
                httpWebRequest.ClientCertificates.Add(certificate);

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
