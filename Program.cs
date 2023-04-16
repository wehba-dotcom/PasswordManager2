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
    public  static void Main(string[] args)
    {
       
       PasswordOne passwordOne = new PasswordOne();
        EASSymetricKey eass = new EASSymetricKey();
       // var key = "b14ca5898a4e4133bbce2ea2315a1916";
 
     Console.WriteLine("Please enter a secret key for the symmetric algorithm.");
        var key = Console.ReadLine();

        //Console.WriteLine(key);
       key = "b14ca5898a4e4133bbce2ea2315a1916";
        // RSAEncryption rsa = new RSAEncryption();

        string cypher = string.Empty;
        Console.WriteLine("Enter your acount name :");
        var AcountName = Console.ReadLine();
        Console.WriteLine("Enter your name :");
        var UserName = Console.ReadLine();
        Console.WriteLine("Enter the Password :");
        var Password = Console.ReadLine();
        if (!string.IsNullOrEmpty(Password))

        {

            cypher = eass.EncryptString(key,Password);
            passwordOne = new(AcountName, UserName, cypher);
            var AllPasswordones = passwordOne.GetPasswordsOnes();
            AllPasswordones.Add(passwordOne);
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
        var plainText =eass.DecryptString(key,cypher);
        Console.WriteLine($"Decrypted Password is : {plainText}");
    }
}