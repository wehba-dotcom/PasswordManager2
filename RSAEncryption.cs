using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordManager2
{
    public class RSAEncryption
    {
        private static RSACryptoServiceProvider rsaprovider = new RSACryptoServiceProvider();
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;
     
       public RSAEncryption()
        {
            _privateKey = rsaprovider.ExportParameters(true);
            _publicKey = rsaprovider.ExportParameters(false);
        }
        public String GetPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _publicKey);
            return sw.ToString();
        }
        public String Encrypt(String Password)
        {
            rsaprovider = new RSACryptoServiceProvider();
            rsaprovider.ImportParameters(_publicKey);
            var password = Encoding.Unicode.GetBytes(Password);
            var cypher = rsaprovider.Encrypt(password, false);
            return Convert.ToBase64String(cypher);

        }
        public String Decrypt(String cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            rsaprovider.ImportParameters(_privateKey);
            var plainText = rsaprovider.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
