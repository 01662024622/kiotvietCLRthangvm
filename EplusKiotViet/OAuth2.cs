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
                Console.Out.WriteLine(e.ToString());
                status = "502";
            }

            Console.Write(status);
            if (status.Length > 20)
            {
                int from = status.IndexOf("\"access_token\":\"", StringComparison.Ordinal) + 16;
                int to = status.IndexOf("\",\"", from, StringComparison.Ordinal);
                status = "Bearer " + status.Substring(from, to - from);
            }

            return status;
        }
    }
}