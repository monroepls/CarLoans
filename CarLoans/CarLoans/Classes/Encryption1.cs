using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CarLoans.Classes
{
    internal class Encryption1
    {

        public static string EncryptionPass(string pass)
        {
            MD5 md5 = MD5.Create();

            byte[] b = Encoding.UTF8.GetBytes(pass);
            byte[] Enc = md5.ComputeHash(b);
            StringBuilder sb = new StringBuilder();
            foreach (var a in Enc) 
                sb.Append(a.ToString("X2"));

            return Convert.ToString(sb);
        }
    
    }
}
