using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Cryptography
{
    public class Cryptography
    {
        public string Encrypt(string item)
        {
            MD5 Hash = MD5.Create();
            byte[] data = Hash.ComputeHash(Encoding.UTF8.GetBytes(item));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
