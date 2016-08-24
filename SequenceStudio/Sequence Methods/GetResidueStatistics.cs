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
        /// <returns>Dictionary()int, string) - The set of residue statistics, that is the number of each residue type in the sequence.</returns>
        public static Dictionary<int, string> GetResidueStatistics(ISequence s)
        {
            // TODO: Add implementation GetResidueStatistics(ISequence s)
            //Residue Statistics are a list of the number of residues, for example 123 A, 107 T, 167 C, 154 G


            return new Dictionary<int, string>();
        }

    }
}
