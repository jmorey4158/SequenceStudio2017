using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    /// <summary>
    /// These Strings are used in Parse() and Validate() methods. The function as Regex tempaltes
    /// for the specific Sequence types and allow the code to determine the validity of the sequence.
    /// They are also used as constants in various methods, such as Translate().
    /// </summary>
    public static class RegexePatterns
    {
        public static string pos_regexDNA = "[ACTG]";
        public static string neg_regexDNA = "[^ACTG]";

        public static string pos_regexConsensusDNA = "[ACTGN*]";
        public static string neg_regexConsensusDNA = "[^ACTGN*]";


        public static string pos_regexRNA = "[ACUG]";
        public static string neg_regexRNA = "[^ACUG]";


        public static string pos_regexAAshort = "[ACDEFGHIKLMNPQRSTVWY]";
        public static string neg_regexAAshort = "[^ACDEFGHIKLMNPQRSTVWY]";


        public static string s_regexAAlong = "(Ala|Cys|Asp|Glu|Phe|Gly|His|Ile|Lys|Leu|" +
                    "Met|Asn|Pro|Gln|Arg|Ser|Thr|Val|Trp|Tyr)";

        public static string s_regexStopCodon = "(TAG|TAA|TGA)";

        public static string s_startCodon = "(ATG)";

        public static string s_stopCodon = "(TAG)";

    }

}
