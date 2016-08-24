using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        // TODO: Complete implementation and Unit Tests
        public static string GetMatchHash(SequenceEnums.MatchType mt, SequenceEnums.SequenceType st, string tId, string pId, int t)
        {
            //Concat all param values into a single string to hash. 
            var uniqueMatchHash = new StringBuilder();
            uniqueMatchHash.Append(mt.ToString());
            uniqueMatchHash.Append(st.ToString());
            uniqueMatchHash.Append(tId);
            uniqueMatchHash.Append(pId);
            uniqueMatchHash.Append(t.ToString());



            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(uniqueMatchHash.ToString()));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}