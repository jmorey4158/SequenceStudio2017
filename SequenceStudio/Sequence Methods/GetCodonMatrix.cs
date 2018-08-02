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
        /// CodonMatrix - generates the CodonMatrix for the given DNA sequence and returns it as a string.
        /// </summary>
        /// <param name="d">DNA class instance - passing a DNA rather than string ensures validity</param>
        /// <returns>String - the CodonMatrix for the sequence</returns>
        /// <remarks><para>The Codon Matrix is the sequential representation of the coding residues of 
        /// the input <paramref name="d"/>. This method assumes that the input DNA sequence is an 
        /// open reading frame (ORFMethods). If the input sequence is not an open reading frame then the 
        /// results might not be useful. The method will continue to the last codon on the sequence
        /// including STOP codons. All 'ATG' codons are translated as a Met residue rather than a 
        /// START codon.</para>
        /// <para>This method returns a String. To obtain the CodonMatrix class instance, 
        /// use AminoAcids.GetCodonMatrix().</para></remarks>
        public static String CodonMatrix(DNA d)
        {
            String dna = d.Strand;
            while (dna.Length % 3 != 0)
            {
                dna = dna.Substring(0, dna.Length - 1);
            }
            StringBuilder sb = new StringBuilder();

            Dictionary<string, string> list = AminoAcids.GetCodonMatrix();

            for (int i = 0; i < dna.Length - 1; i += 3)
            {
                String s = dna.Substring(i, 3);
                foreach (KeyValuePair<string, string> kp in list)
                {
                    if (kp.Value == s)
                    {
                        sb.Append(kp.Key);
                    }
                }
            }
            return sb.ToString();
        }


    }
}