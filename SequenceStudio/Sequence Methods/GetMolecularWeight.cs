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
        /// Helper Method GetMolecularWeight - 
        /// </summary>
        /// <param name="s" cref="ISequence">Any ISequence-compliant class instance.</param>
        /// <returns>Decimal - The molecular weight of the input sequence, in Daltons.</returns>
        /// <remarks>This method calls the private helpers CalcMolWeightNucleotide() or CalcMolWeightPoly() to do the calculations.</remarks>
        public static decimal GetMolecularWeight(ISequence s)
        {
            switch (s.SequenceType)
            {
                case SequenceEnums.SequenceType.DNA:
                case SequenceEnums.SequenceType.RNA:
                    return CalcMolWeightNucleotide(s.Strand);

                case SequenceEnums.SequenceType.Polypeptide:
                    return CalcMolWeightPoly(s.Strand);

                default:
                    return -1;
            }
        }
    }
}

