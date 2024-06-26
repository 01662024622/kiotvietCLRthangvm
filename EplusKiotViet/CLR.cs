﻿using EplusKiotViet;
using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;
using System.Net;

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
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
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
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
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
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string listIn = Util.UpdateIn(code.Trim(), amount.Trim());
        string res = Api.PUT(URL_API + INVENTORY, listIn, token);

        text = res;
    }

    [SqlProcedure]
    public static void UpdateAccDoc(String id, String description, String status)
    {
        // ssl2
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
        // Display the number of command line arguments.

        string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
        string token = OAuth2.Api(URL_TOKEN, body);
        string listIn = BodyRequest.UpdateAccdoc(description.Trim(), status.Trim());
        Api.PUT(URL_API + ACCDOC + "/" + id, listIn, token);
    }
}