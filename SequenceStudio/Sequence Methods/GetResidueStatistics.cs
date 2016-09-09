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
        /// Helper Method GetResidueStatistics - Returns the set of Residue Statistics for the given ISequence-compliant class instance.
        /// 
        ///     Residue Statistics are a list of the number of residues, for example, for a DNA sequence: 123 A, 107 T, 167 C, 154 G
        /// </summary>
        /// <param name="s" cref="ISequence">Any ISequence-compliant class instance.</param>
        /// <returns>Dictionary(int, string) - The set of residue statistics, that is the number of each residue type in the sequence.</returns>
        public static Dictionary<string, int> GetResidueStatistics(ISequence s)
        {
            if (s is DNA || s is RNA)
            {
                Dictionary<String, Int32> units = new Dictionary<String, Int32>();
                Int32 count = 0;
                String[] s_DNA = new String[5] { "A", "T", "C", "G", "U" };
                String seq = s.Strand;

                foreach (string st in s_DNA)
                {
                    for (Int32 index = 0; index < seq.Length - 1; ++index)
                    {
                        if (seq.Substring(index, 1) == st)
                        {
                            count++;
                        }
                    }
                    units.Add(st, count);
                    count = 0;
                }
                return units;
            }
            else
            {
                List<AminoAcids.AminoAcidBase> aa = AminoAcids.GetAminoAcidList();
                String[] s_AA = new String[20];
                Int32 i = 0;
                foreach (AminoAcids.AminoAcidBase b in aa)
                {
                    s_AA[i] = b.Initial.ToString();
                    i++;
                }

                Dictionary<String, Int32> units = new Dictionary<String, Int32>();
                String seq = s.Strand;
                Int32 count = 0;

                foreach (string st in s_AA)
                {
                    for (Int32 index = 0; index < seq.Length - 1; ++index)
                    {
                        if (seq.Substring(index, 1) == st)
                        {
                            count++;
                        }
                    }
                    units.Add(st, count);
                    count = 0;
                }
                return units;

            }
        }

    }
}
