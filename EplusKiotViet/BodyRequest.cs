namespace EplusKiotViet
{
    public class BodyRequest
    {
        public static string GetBodyCustomer(string code, string name, string tel, string address)
        {
            return "{" +
                   $"\"code\": \"{code}\"," +
                   $"\"name\": \"{name}\"," +
                   $"\"contactNumber\": \"{tel}\"," +
                   $"\"address\": \"{address}\"," +
                   "\"branchId\":164049," +
                   "\"groupIds\":116050" +
                   "}";
        }


        public static string GetBodySku(string code, string name, string unit)
        {
            return "{" +
                   $"\"code\": \"{code}\"," +
                   $"\"name\": \"{name}\"," +
                   "\"categoryId\": 720186," +
                   "\"allowsSale\": true," +
                   $"\"unit\": \"{unit}\"," +
                   "\"branchId\":164049" +
                   "}";
        }

        public static string UpdateAccdoc(string description, string status)
        {
            return "{" +
                   $"\"description\": \"{description}-{status}\"" +
                   "}";
        }

        public static string GetBodyInventory(string id, string amount)
        {
            return $"{{\"id\":{id}," +
                   "\"inventories\": " +
                   "[" +
                   "{" +
                   "\"branchId\": 164049," +
                   $"\"onHand\": {amount}" +
                   "}" +
                   "]" +
                   "}";
        }

        public static string getS(int price)
        {
            return "{" +
                $"\"basePrice\": {price}" +
            "}";
        }

        public static string GetbodyAuth(string id, string secret)
        {
            return "scopes=PublicApi.Access&grant_type=client_credentials&client_id=" + id + "&client_secret=" + secret;
        }


    }
}