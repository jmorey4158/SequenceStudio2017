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
        /// <summary>
        /// Helper Method GetISequenceHash - This method returns the MD5 hash of the ISequence.Strand (sequence string).
        /// This has is used as the identifier of the ISequence object for storing and comparing in the DB.
        /// </summary>
        /// <param name="s">String - the string representing a valid ISequence-compliant class instance Strand property.</param>
        /// <returns></returns>
        /// <remarks>This Method is not intended for public use and should only be called from ISequence-compliant constructors.</remarks>
        public static string GetISequenceHash(string s)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(s));

            // Create a new StringBuilder to collect the bytes
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