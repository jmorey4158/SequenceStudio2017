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
    }
}