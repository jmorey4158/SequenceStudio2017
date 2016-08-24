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
        /// Helper Method GetReverseStrand - Creates the reverse strand for a DNA sequence. 
        ///     The reverse strand is the strand flipped backwards.
        ///     
        ///     For example for the strand'ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA' 
        ///     the reverse would be   'AGTCGTACGATGCTCGTACGTAGCTGATGCTCGATCA'.
        /// </summary>
        /// <param name="d" cref="DNA">DNA Class Instance - the (string) DNA.Strand is used as the input string this method.</param>
        /// <returns>String - the reverse strand.</returns>
        public static string GetReverseStrand(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            string seq = d.Strand;

            for (int index = seq.Length - 1; index >= 0; index--)
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }


        /// <summary>
        /// Helper Method GetReverseComplimentStrand - Creates the compliment of the reverse strand for a DNA sequence. 
        ///     The reverse compliment strand is the compliment of the strand flipped backwards.
        ///     
        ///     For example for the strand      'ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA' 
        ///     the reverse compliment would be 'TCAGCATGCTACGAGCATGCATCGACTACGAGCTAGT'.
        /// </summary>
        /// <param name="d" cref="DNA">DNA Class Instance - the (string) DNA.Strand is used as the input string this method.</param>
        /// <returns>String - the reverse strand.</returns>
        public static string GetReverseComplimentStrand(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            string seq = GetComplimentStrand(d);

            for (int index = seq.Length - 1; index >= 0; index--)
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }

    }


}
