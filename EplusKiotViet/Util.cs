using System;
using System.Dynamic;

namespace EplusKiotViet
{
    public class Util
    {
        public static string GetParam(String data, String param, bool type = true)
        {
            if (type)
            {
                int from = data.IndexOf("\"" + param + "\":", StringComparison.Ordinal) + 3 + param.Length;
                if (from - param.Length < 3)
                {
                    return "";
                }
                int to = data.IndexOf(",\"", from, StringComparison.Ordinal);
                return data.Substring(from, to - from);
            }
            else
            {
                int from = data.IndexOf("\"" + param + "\":\"", StringComparison.Ordinal) + 4 + param.Length;
                if (from - param.Length < 4)
                {
                    return "";
                }
                int to = data.IndexOf("\",\"", from, StringComparison.Ordinal);
                return data.Substring(from, to - from);
            }
        }

        public static string UpdateIn(string idString, string amountString, string token)
        {
            string[] ids = idString.Split(',');
            string[] amounts = amountString.Split(',');
            string[] request = new string[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                request[i] = BodyRequest.GetBodyInventory(ids[i], amounts[i]);
            }

            string inventories = string.Join(",", request);
            return "{ \"listProducts\": [" + inventories + "]}";
        }
    }
}