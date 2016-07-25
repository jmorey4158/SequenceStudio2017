using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public static partial class SequenceMethods
    {

        public static string GetTranscript(DNA d)
        {
            var sb = new StringBuilder(d.Strand);

            sb.Replace("T", "U");

            return sb.ToString();
        }

    }


}
