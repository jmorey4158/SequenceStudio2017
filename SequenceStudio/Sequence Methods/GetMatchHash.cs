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
        /// Public Method FindMatches - This is the 'user-friendly' method that is called by external code. 
        /// This method determines which delegate should be called and calls it, then returns the result to the caller.
        /// 
        /// </summary>
        /// <param name="matchType">MatchType - The type of matching requested.</param>
        /// <remarks>This pattern was chosen to allow future extension and flexibility without forcing the
        ///  caller to adapt to changes. The caller simply calls this method and we do the right thing under the covers.</remarks>
        /// <param name="sequnceType"></param>
        /// <param name="templateID">String - The hash that uniquely identifies the Sequence instance.</param>
        /// <param name="patternID">String - The hash that uniquely identifies the Sequence instance.</param>
        /// <param name="threshold">Int - The threshold at or above which the match is valid.</param>
        /// <returns></returns>
        public static string GetMatchHash(SequenceEnums.MatchType matchType, 
            SequenceEnums.SequenceType sequnceType, string templateID, string patternID, int threshold)
        {
            // Concatenate all parameter values into a single string to hash. 
            //  all of these metadata are needed to uniquely identify and represent
            //  the Match. 
            var uniqueMatchHash = new StringBuilder();
            uniqueMatchHash.Append(matchType.ToString());
            uniqueMatchHash.Append(sequnceType.ToString());
            uniqueMatchHash.Append(templateID);
            uniqueMatchHash.Append(patternID);
            uniqueMatchHash.Append(threshold.ToString());

            // TODO: Complete implementation and Unit Tests

            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(uniqueMatchHash.ToString()));

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