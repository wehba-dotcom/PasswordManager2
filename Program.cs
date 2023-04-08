// See https://aka.ms/new-console-template for more information

using PasswordManager2;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Xml.Linq;
using System;

internal class Program
{
    //public static class JsonFileUtils
    //{
    //    private static readonly JsonSerializerOptions _options =
    //        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    //    public static void SimpleWrite(object obj, string fileName)
    //    {
    //        var jsonString = JsonSerializer.Serialize(obj, _options);
    //        File.WriteAllText(fileName, jsonString);
    //    }
    //}
    //public static class JsonFileUtils
    //{
    //    public static readonly JsonSerializerSettings _options
    //       = new() { NullValueHandling = NullValueHandling.Ignore };

    //    public static void SimpleWrite(object obj, string fileName)
    //    {
    //        var jsonString = JsonConvert.SerializeObject(obj, _options);
    //        File.WriteAllText(fileName, jsonString);
    //    }
    //}

    //public static void StreamWrite(object obj, string fileName)
    //{

    //    var filename = "products.json";
    //    using var fileStream = File.Create(filename);
    //    using var utf8JsonWriter = new Utf8JsonWriter(fileStream);
    //    System.Text.Json.JsonSerializer.Serialize(utf8JsonWriter, obj, _options);
    //}


    private static void Main(string[] args)
    {
        //StreamWriter str = new StreamWriter("products.json");
       PasswordOne passwordOne = new PasswordOne();
        RSAEncryption rsa = new RSAEncryption();
        
        string cypher = string.Empty;

        Console.WriteLine($"public Key : {rsa.GetPublicKey()}\n");
        Console.WriteLine("Enter your acount name :");
        var AcountName = Console.ReadLine();
        Console.WriteLine("Enter your name :");
        var UserName = Console.ReadLine();
        Console.WriteLine("Enter the Password :");
        var Password = Console.ReadLine();
        if (!string.IsNullOrEmpty(Password))

        {

            cypher = rsa.Encrypt(Password);

              passwordOne = new(AcountName, UserName, cypher);
            var AllPasswordones = passwordOne.GetPasswordsOnes();
            AllPasswordones.Add(passwordOne);
            var fileName = @"products.json";
            string json = System.Text.Json.JsonSerializer.Serialize(AllPasswordones);
            File.WriteAllText(@"C:\Users\WEHBA\OneDrive\Skrivebord\products.json", json);

            StreamReader r = new StreamReader(@"C:\Users\WEHBA\OneDrive\Skrivebord\products.json");
            string Json = r.ReadToEnd();
            Console.WriteLine($"Your Creidential  is :\n Acount name : {AcountName}\n Name : {UserName}\n Password: {cypher}");
            AllPasswordones = JsonConvert.DeserializeObject<List<PasswordOne>>(Json);
            foreach (var item in AllPasswordones)
            {

                Console.WriteLine(@" {0}   {1}   {2} " , item.AcountName,item.UserName,item.password);
            }
         
           
        }
       
        
     

        Console.WriteLine(" Press any key to Decrypt the Password as yopu enteres ");
        Console.ReadLine();
        var plainText = rsa.Decrypt(cypher);
        Console.WriteLine($"Decrypted Password is : {plainText}");
    }
}