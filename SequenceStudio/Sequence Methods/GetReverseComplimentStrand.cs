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

        /// <summary>
        /// Helper Method GetReverseComplimentStrand - Creates the compliment of the reverse strand for an RNA sequence. 
        ///     The reverse compliment strand is the compliment of the strand flipped backwards.
        ///     
        ///     For example for the strand      'ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA' 
        ///     the reverse compliment would be 'TCAGCATGCTACGAGCATGCATCGACTACGAGCTAGT'.
        /// </summary>
        /// <param name="d" cref="RNA">RNA Class Instance - the (string) RNA.Strand is used as the input string this method.</param>
        /// <returns>String - the reverse strand.</returns>
        public static string GetReverseComplimentStrand(RNA r)
        {
            StringBuilder sb = new StringBuilder();
            string seq = GetComplimentStrand(r);

            for ( int index = seq.Length - 1; index >= 0; index-- )
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }


    }
}
