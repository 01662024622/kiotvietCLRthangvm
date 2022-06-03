using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using EplusKiotViet;
using Microsoft.SqlServer.Server;

public class CLR
{
    private const string CLIENT_SECRET = "9BE94DC179BB890F4AB1DC7EFF16F819B10C11C5";
    private const string CLIENT_ID = "2c181bb5-10a9-4063-8a94-9e89f20564f0";
    private const string URL_TOKEN = "https://id.kiotviet.vn/connect/token";
    private const string URL_API = "https://public.kiotapi.com/";
    private const string CUSTOMER = "customers";
    private const string SKU = "products";
    private const string ACCDOC = "invoices";
    private const string INVENTORY = "listupdatedproducts";

    // tooken

    [SqlProcedure]
    public static void CreateCustomer(String code, String name, String tel, String address, out SqlString id,
        out SqlString log)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string bodyCustomer = BodyRequest.GetBodyCustomer(code.Trim(), name.Trim(), tel.Trim(), address.Trim());
        string customer = Api.Post(URL_API + CUSTOMER, bodyCustomer, token);
        string res = Util.GetParam(customer, "id");
        id = res;
        log = customer;
    }

    [SqlProcedure]
    public static void CreateSku(String code, String name, String unit, out SqlString id, out SqlString text)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string bodySku = BodyRequest.GetBodySku(code.Trim(), name.Trim(), unit.Trim());
        string sku = Api.Post(URL_API + SKU, bodySku, token);
        string res = Util.GetParam(sku, "id");
        id = res;
        text = sku;
    }

    [SqlProcedure]
    public static void UpdateInventory(String code, string amount, out SqlString text)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string listIn = Util.UpdateIn(code.Trim(), amount.Trim());
        string res = Api.PUT(URL_API + INVENTORY, listIn, token);

        text = res;
    }

    [SqlProcedure]
    public static void UpdateAccDoc(string id, string description, string status)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType) (0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string listIn = BodyRequest.UpdateAccdoc(description.Trim(), status.Trim());
        Api.PUT(URL_API + ACCDOC + "/" + id, listIn, token);
    }

    public static void Main()
    {
        Dictionary<int, int> a = new Dictionary<int, int>();
        a.Add(20906691,105000);
        a.Add(20906690,58000);
        a.Add(20906708,58000);
        a.Add(20906692,55000);
        a.Add(20906693,43000);
        a.Add(20906722,43000);
        a.Add(20906732,40000);
        a.Add(20906721,80000);
        a.Add(20906729,155000);
        a.Add(20906694,90000);
        a.Add(20906696,80000);
        a.Add(20906737,155000);
        a.Add(20906742,83000);
        a.Add(20906741,95000);
        a.Add(20906738,125000);
        a.Add(20906743,165000);
        a.Add(20906724,165000);
        a.Add(20906731,195000);
        a.Add(20906748,125000);
        a.Add(20906747,65000);
        a.Add(20906715,335000);
        a.Add(20906725,95000);
        a.Add(20906716,355000);
        a.Add(20906707,355000);
        a.Add(20906698,455000);
        a.Add(20906728,33000);
        a.Add(20906717,48000);
        a.Add(20906750,55000);
        a.Add(20906709,48000);
        a.Add(20906720,45000);
        a.Add(20906723,48000);
        a.Add(20906736,175000);
        a.Add(20906727,165000);
        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        foreach (var keyValuePair in a)
        {
            
            string listIn = BodyRequest.getS(keyValuePair.Value);
            Console.WriteLine(Api.PUT(URL_API + SKU + "/" + keyValuePair.Key, listIn, token));
        }
    }
    
}