using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public static partial class SequenceMethods
    {

        public static decimal GetMolecularWeight(ISequence s)
        {
            switch (s.SequenceType)
            {
                case SequenceEnums.SequenceType.DNA:
                case SequenceEnums.SequenceType.RNA:
                    return CalcMolWeightNucleotide(s);

                case SequenceEnums.SequenceType.Polypeptide:
                    return CalcMolWeightPoly(s);

                case SequenceEnums.SequenceType.ConsensusDNA:
                    return -1;
                default:
                    return -1;
            }
        }
    }
}

