using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public static partial class SequenceMethods
    {
        /// <summary>
        /// Helper Method GetTranscript - Gets the RNA transcript for the given DNA class instance.
        /// </summary>
        /// <param name="d" cref="DNA">A DNA class instance.</param>
        /// <returns>String - the RNA transcript for the given DNA class instance.</returns>
        public static string GetTranscript(DNA d)
        {
            var sb = new StringBuilder(d.Strand);

            sb.Replace("T", "U");

            return sb.ToString();
        }

    }


}
