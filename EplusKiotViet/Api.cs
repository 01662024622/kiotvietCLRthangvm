using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EplusKiotViet
{
    public class Api
    {
        public static string Post(string url, string body, string auth)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            // add authorization to header
            httpWebRequest.Headers["Authorization"] = auth;
            httpWebRequest.Headers["Retailer"] = "earldom";

            // add method
            httpWebRequest.Method = "POST";
            // use stream write
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(body);
                streamWriter.Close();
            }

            return getRespon(httpWebRequest);
        }

        public static string PUT(string url, string body, string auth)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            // add authorization to header
            httpWebRequest.Headers["Authorization"] = auth;
            httpWebRequest.Headers["Retailer"] = "earldom";

            // add method
            httpWebRequest.Method = "PUT";
            // use stream write
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(body);
                streamWriter.Close();
            }

            return getRespon(httpWebRequest);
        }

        public static string Get(string url, string auth)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            // add authorization to header
            httpWebRequest.Headers["Authorization"] = auth;
            httpWebRequest.Headers["Retailer"] = "earldom";

            // add method
            httpWebRequest.Method = "GET";
            // use stream write
            return getRespon(httpWebRequest);
        }

        private static string getRespon(HttpWebRequest httpWebRequest)
        {
            string res;
            try
            {
                var response = (HttpWebResponse) httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader streamReader =
                           new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        res = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    res = "501";
                }

                response.Close();
            }
            catch (Exception e)
            {
                res = e.ToString();
            }

            return res;
        }
    }
}