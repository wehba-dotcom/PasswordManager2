using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordManager2
{
    public class PasswordOne
    {
        public  List<PasswordOne> GetPasswordsOnes() => new()
    {
        new("hotmail", "weee", "qwew"),
        new("Facebook","daswe","allord"),
        new("Massenger","qqw","qwew")
    };
        public PasswordOne()
        {
        }

        public PasswordOne(string? acountName, string? userName, string cypher)
        {
            AcountName = acountName;
            UserName = userName;
            password = cypher;
        }

       

        public int id { get; set; }
        public string AcountName { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }

       
    }
   

    // public override string ToString() => JsonSerializer.Serialize<PasswordOne>(this);
}
