using System;
using System.Collections.Generic;
using System.Linq;

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
                   "\"branchId\":3634," +
                   "\"groupIds\":116050" +
                   "}";
        }


        public static string GetBodySku(string code, string name, string unit)
        {
            return "{" +
                   $"\"code\": \"{code}\"," +
                   $"\"name\": \"{name}\"," +
                   "\"categoryId\": 720186," +
                   "\"allowsSale\": false," +
                   $"\"unit\": \"{unit}\"," +
                   "\"branchId\":3634" +
                   "}";
        }

        public static string UpdateAccdoc(string description , string status)
        {
            return "{" +
                   $"\"description\": \"{description}-{status}\"" +
                   "}";
        }

        public static string GetBodyInventory(string id,string amount)
        {
            return $"{{\"id\":{id}," +
                   "\"inventories\": " +
                   "[" +
                   "{" +
                   "\"branchId\": 3634," +
                   $"\"onHand\": {amount}" +
                   "}," +
                   "{" +
                   "\"branchId\": 63506," +
                   $"\"onHand\": {amount}" +
                   "}," +
                   "{" +
                   "\"branchId\": 164049," +
                   $"\"onHand\": {amount}" +
                   "}," +
                   "{" +
                   "\"branchId\": 19576," +
                   $"\"onHand\": {amount}" +
                   "}," +
                   "{" +
                   "\"branchId\": 58187," +
                   $"\"onHand\": {amount}" +
                   "}" +
                   "]" +
                   "}";
        }

        public static string getS(int price)
        {
            return "{"+
                $"\"basePrice\": {price}"+
            "}";
        }

        public static string GetbodyAuth(string id, string secret)
        {
            return "scopes=PublicApi.Access&grant_type=client_credentials&client_id=" + id + "&client_secret=" + secret;
        }


    }
}