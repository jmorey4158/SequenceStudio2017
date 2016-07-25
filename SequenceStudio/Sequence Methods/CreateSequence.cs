using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public  static partial class SequenceMethods
    {
        public static ISequence CreateSequence(string strand, SequenceEnums.SequenceType st, SequenceEnums.SequenceOriginType so)
        {
            switch (st)
            {
                case (SequenceEnums.SequenceType.DNA):
                    return new DNA(strand, so);

                case (SequenceEnums.SequenceType.RNA):
                    return new RNA(strand, so);

                case (SequenceEnums.SequenceType.Polypeptide):
                    return new Polypeptide(strand, so);

                case (SequenceEnums.SequenceType.ConsensusDNA):
                    return new ConsensusDNA(strand, so);

                default:
                    throw new SequenceException(
                        string.Format("The specified 'strand' {0} did not match the specified SequenceType {1}.", strand, st));
            }
            
        }
    }
}
