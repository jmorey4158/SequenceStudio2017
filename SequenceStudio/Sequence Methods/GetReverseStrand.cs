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
        /// Helper Method GetReverseStrand - Creates the reverse strand for an RNA sequence. 
        ///     The reverse strand is the strand flipped backwards.
        ///     
        ///     For example for the strand'ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA' 
        ///     the reverse would be   'AGTCGTACGATGCTCGTACGTAGCTGATGCTCGATCA'.
        /// </summary>
        /// <param name="d" cref="RNA">RNA Class Instance - the (string) RNA.Strand is used as the input string this method.</param>
        /// <returns>String - the reverse strand.</returns>
        public static string GetReverseStrand(RNA r)
        {
            StringBuilder sb = new StringBuilder();
            string seq = r.Strand;

            for ( int index = seq.Length - 1; index >= 0; index-- )
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }

    }
}
