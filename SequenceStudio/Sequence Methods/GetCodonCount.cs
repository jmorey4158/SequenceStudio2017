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
        /// Counts all of the DNA codons in a DNA sequence.
        /// </summary>
        /// <param name="s">DNA class instance - the DNA sequence to operate upon.</param>
        /// <returns>Dictionary(String,Int32) - the list of the codons and number of instances in 
        /// the <paramref name="s"/>.</returns>
        /// <remarks>This methods instantiates a CodonMatrix and uses that to 
        /// match with the <paramref name="s"/>.</remarks>
        public static Dictionary<String, Int32> CodonCount(DNA d)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            Dictionary<string, string> cl = AminoAcids.GetCodonMatrix();
            int count = 0;
            String seq = d.Strand;

            while (seq.Length % 3 != 0)
            {
                seq = seq.Substring(0, seq.Length - 1);
            }

            foreach (KeyValuePair<string, string> kp in cl)
            {
                count = 0;
                for (int i = 0; i < seq.Length - 1; i += 3)
                {
                    if (seq.Substring(i, 3) == kp.Value)
                    {
                        count++;
                    }
                }
                list.Add(kp.Key, count);
            }
            return list;
        }



        /// <summary>
        /// Calculates the percentage of the DNA codons in a DNA sequence. 
        /// </summary>
        /// <param name="s">DNA class instance - the DNA strand to operate upon.</param>
        /// <returns>Dictionary(String,Int32) - the list of the codons and number of instances in 
        /// the <paramref name="s"/>.</returns>
        /// <remarks>This methods calls the CodonCount(Sequence s) method
        /// and uses the results of that method to calculate the percentages.<paramref name="s"/>.</remarks>
        public static Dictionary<String, Double> CodonPercentage(DNA d)
        {
            Dictionary<string, int> cc = CodonCount(d); //calls CodonCount method to get count of codons

            Dictionary<string, double> list = new Dictionary<string, double>();
            double p = d.Strand.Length / 3;

            foreach (KeyValuePair<string, int> kc in cc)
            {
                list.Add(kc.Key, ((double)(kc.Value / p) * 100));
            }

            return list;
        }


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