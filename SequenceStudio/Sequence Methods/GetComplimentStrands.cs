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
        /// Helper Method GetComplimentStrand - Creates the compliment strand for a DNA sequence. 
        ///     The compliment strand is the one on the other side of the double helix, where for each 'A'
        ///     in the input strand is a 'T' in the compliment strand ('U' in RNA).
        ///     
        ///     For example for the strand'ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA' 
        ///     the compliment would be   'TGATCGAGCATCAGCTACGTACGAGCATCGTACGACT'.
        /// </summary>
        /// <param name="d" cref="DNA">DNA Class Instance - the (string) DNA.Strand is used as the input string this method.</param>
        /// <returns>String - the compliment strand.</returns>
        public static string GetComplimentStrand(DNA d)
        {
            var sb = new StringBuilder();
            string seq = d.Strand;

            for (int index = 0; index <= seq.Length - 1; index++)
            {
                switch (seq.Substring(index, 1))
                {
                    case "A":
                        sb.Append("T");
                        break;
                    case "C":
                        sb.Append("G");
                        break;
                    case "T":
                        sb.Append("A");
                        break;
                    case "G":
                        sb.Append("C");
                        break;
                    case "N":
                        sb.Append("N");
                        break;
                    default:
                        break;
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Helper Method GetComplimentStrand - Creates the compliment strand for an RNA sequence. 
        ///     The compliment strand is the one on the other side of the double helix, where for each 'A'
        ///     in the input strand is a 'U' in the compliment strand.
        ///     
        ///     For example for the strand'ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA' 
        ///     the compliment would be   'TGATCGAGCATCAGCTACGTACGAGCATCGTACGACT'.
        /// </summary>
        /// <param name="d" cref="RNA">RNA Class Instance - the (string) RNA.Strand is used as the input string this method.</param>
        /// <returns>String - the compliment strand.</returns>
        public static string GetComplimentStrand(RNA r)
        {
            var sb = new StringBuilder();
            string seq = r.Strand;

            for (int index = 0; index <= seq.Length - 1; index++)
            {
                switch (seq.Substring(index, 1))
                {
                    case "A":
                        sb.Append("U");
                        break;
                    case "C":
                        sb.Append("G");
                        break;
                    case "U":
                        sb.Append("A");
                        break;
                    case "G":
                        sb.Append("C");
                        break;
                    case "N":
                        sb.Append("N");
                        break;
                    default:
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
