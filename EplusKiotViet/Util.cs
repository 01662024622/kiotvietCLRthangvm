using System;
using System.Dynamic;

namespace EplusKiotViet
{
    public class Util
    {
        public static string GetParam(String data, String param, bool type = true)
        {
            int from = data.IndexOf("\"" + param + "\":", StringComparison.Ordinal) + 3 + param.Length;
            if (from - param.Length < 3)
            {
                return "";
            }

            if (type)
            {
                int to = data.IndexOf(",\"", from, StringComparison.Ordinal);
                return data.Substring(from, to - from);
            }
            else
            {
                int to = data.IndexOf("\",\"", from, StringComparison.Ordinal);
                return data.Substring(from, to - from);
            }
        }

        public static string UpdateIn(string codeString, string amountString, string token)
        {
            string[] codes = codeString.Split(',');
            string[] amounts = amountString.Split(',');
            string[] request = new string[codes.Length];

            for (int i = 0; i < codes.Length; i++)
            {
                string sku = Api.Get("https://public.kiotapi.com/products/code/" + codes[i], token);
                string id = Util.GetParam(sku, "id");
                Console.WriteLine(id);
                request[i] = BodyRequest.GetBodyInventory(id, amounts[i]);
            }

            string inventories = string.Join(",", request);
            return "{ \"listProducts\": [" + inventories + "]}";
        }
    }
}