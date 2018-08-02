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
        /// Helper Method GetTranslation - Gets the Polypeptide translation for the given RNA class instance.
        /// </summary>
        /// <param name="d" cref="RNA">An RNA class instance.</param>
        /// <returns>String - the Polypeptide translation for the given RNA.</returns>
        public static string GetTranslation(RNA r)
        {
            String seq = r.Strand;

            StringBuilder sb = new StringBuilder();
            for (Int32 index = 0; index <= seq.Length - 3; index += 3)
            {
                #region SWITCH
                switch (seq.Substring(index, 3))
                {

                    case "GCU":
                        sb.Append("A");
                        break;
                    case "GCC":
                        sb.Append("A");
                        break;
                    case "GCA":
                        sb.Append("A");
                        break;
                    case "GCG":
                        sb.Append("A");
                        break;


                    case "UGU":
                        sb.Append("C");
                        break;
                    case "UGC":
                        sb.Append("C");
                        break;


                    case "GAU":
                        sb.Append("D");
                        break;
                    case "GAC":
                        sb.Append("D");
                        break;


                    case "GAA":
                        sb.Append("E");
                        break;
                    case "GAG":
                        sb.Append("E");
                        break;


                    case "UUU":
                        sb.Append("F");
                        break;
                    case "UUC":
                        sb.Append("F");
                        break;


                    case "GGU":
                        sb.Append("G");
                        break;
                    case "GGC":
                        sb.Append("G");
                        break;
                    case "GGA":
                        sb.Append("G");
                        break;
                    case "GGG":
                        sb.Append("G");
                        break;


                    case "CAU":
                        sb.Append("H");
                        break;
                    case "CAC":
                        sb.Append("H");
                        break;


                    case "AUU":
                        sb.Append("I");
                        break;
                    case "AUC":
                        sb.Append("I");
                        break;
                    case "AUA":
                        sb.Append("I");
                        break;


                    case "AAA":
                        sb.Append("K");
                        break;
                    case "AAG":
                        sb.Append("K");
                        break;


                    case "UUA":
                        sb.Append("L");
                        break;
                    case "UUG":
                        sb.Append("L");
                        break;
                    case "CUU":
                        sb.Append("L");
                        break;
                    case "CUC":
                        sb.Append("L");
                        break;
                    case "CUA":
                        sb.Append("L");
                        break;
                    case "CUG":
                        sb.Append("L");
                        break;


                    case "AUG":
                        sb.Append("M");
                        break;


                    case "AAU":
                        sb.Append("N");
                        break;
                    case "AAC":
                        sb.Append("N");
                        break;


                    case "CCU":
                        sb.Append("P");
                        break;
                    case "CCC":
                        sb.Append("P");
                        break;
                    case "CCA":
                        sb.Append("P");
                        break;
                    case "CCG":
                        sb.Append("P");
                        break;


                    case "CAA":
                        sb.Append("Q");
                        break;
                    case "CAG":
                        sb.Append("Q");
                        break;


                    case "CGU":
                        sb.Append("R");
                        break;
                    case "CGC":
                        sb.Append("R");
                        break;
                    case "CGA":
                        sb.Append("R");
                        break;
                    case "CGG":
                        sb.Append("R");
                        break;
                    case "AGA":
                        sb.Append("R");
                        break;
                    case "AGG":
                        sb.Append("R");
                        break;


                    case "UCU":
                        sb.Append("S");
                        break;
                    case "UCC":
                        sb.Append("S");
                        break;
                    case "UCA":
                        sb.Append("S");
                        break;
                    case "UCG":
                        sb.Append("S");
                        break;
                    case "AGU":
                        sb.Append("S");
                        break;
                    case "AGC":
                        sb.Append("S");
                        break;


                    case "ACU":
                        sb.Append("T");
                        break;
                    case "ACC":
                        sb.Append("T");
                        break;
                    case "ACA":
                        sb.Append("T");
                        break;
                    case "ACG":
                        sb.Append("T");
                        break;


                    case "UGA":
                        sb.Append("U");
                        break;


                    case "GUU":
                        sb.Append("V");
                        break;
                    case "GUC":
                        sb.Append("V");
                        break;
                    case "GUA":
                        sb.Append("V");
                        break;
                    case "GUG":
                        sb.Append("V");
                        break;


                    case "UGG":
                        sb.Append("W");
                        break;


                    case "UAU":
                        sb.Append("Y");
                        break;
                    case "UAC":
                        sb.Append("Y");
                        break;


                    case "UAA":
                        sb.Append("*");
                        break;
                    case "UAG":
                        sb.Append("*");
                        break;

                    default:
                        sb.Append("_");
                        break;
                }
                #endregion
            }
            return sb.ToString();
        }

    }
}
