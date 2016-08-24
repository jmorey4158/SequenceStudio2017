using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public  static partial class SequenceMethods
    {
        /// <summary>
        /// Public Method <c>CreateSequence</c> - This method create ISequence-compliant sequence class instances given the 
        ///     specified value.
        /// </summary>
        /// <param name="strand">String - The string that represents the sequence. 
        ///     This strand must comply with the pattern for the intended SequenceType or a SequenceExdeption will be thrown.</param>
        /// <param name="st" cref="SequenceEnums.SequenceType">Enum - The SequenceType that the method consumer intends to instantiate. </param>
        /// <param name="so" cref="SequenceEnums.SequenceOriginType">Enum - The SequenceOriginType that the method consumer intends to instantiate. By default this is 'Manual'.</param>
        /// <returns cref="ISequence">An ISequence-compliant class instance.</returns>
        /// <exception cref="SequenceException">SequenceException with information about the specific error.</exception>
        public static ISequence CreateSequence(string strand, 
            SequenceEnums.SequenceType st, SequenceEnums.SequenceOriginType so)
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
                    throw new SequenceException($"The specified 'strand' {strand} did not match the specified SequenceType {st}.");
            }
            
        }
    }
}
