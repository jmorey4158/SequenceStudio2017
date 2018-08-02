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
    }
}