using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    class UnitPatterns
    {

        public static String[] s_DNA = new String[4] { "A", "T", "C", "G" };

        public static String[] s_RNA = new String[4] { "A", "U", "C", "G" };

        public static String[] s_Polypeptide = new String[20] { "A", "R", "N", "D",
                                                                    "C", "E", "Q", "G",
                                                                    "H", "I", "L", "K",
                                                                    "M", "F", "P", "S",
                                                                    "T", "W", "Y", "V"};


        public static String p_DNA = "ACTG";

        public static String p_RNA = "AUCG";

        public static String p_Polypeptide = "ARNDCEQGHILKMFPSTWYV";

        public static String tripleStop = "TAGTAATGA";

        public static String tripleStart = "AGTAATGAT";

        public static String tripleStart2 = "GCTATTACT";

    }
}
