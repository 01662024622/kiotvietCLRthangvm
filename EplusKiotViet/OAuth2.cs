using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EplusKiotViet
{
    public class OAuth2
    {
        public static string Api(string url, string body)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            // add authorization to header
            // add method
            httpWebRequest.Method = "POST";
            // use stream write
            string status;
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(body);
                    streamWriter.Close();
                }

                var response = (HttpWebResponse) httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader streamReader =
                           new StreamReader(response.GetResponseStream() ??
                                            throw new InvalidOperationException()))
                    {
                        status = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                else
                {
                    status = "501";
                }

                response.Close();
            }
            catch (Exception e)
            {
                status = e.ToString();
            }

            if (status.Length > 20)
            {
                status = "Bearer " + Util.GetParam(status, "access_token", false);
            }

            Console.Write(status);
            return status;
        }
    }
}