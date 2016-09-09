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
        /// Helper Method CalcMolWeight - Calculate the Molecular Weight (in Daltons) of the specified ISequence-compliant sequence 
        ///     (e.g. DNA, RNA, and Polypeptide).
        /// </summary>
        /// <param name="s">Any ISequence-compliant Sequence class instance</param>
        /// <returns>Decimal - the molecular weight of the input sequence in Daltons.</returns>
        /// <remarks>This public-facing method calls the private methods CalcMolWeightNucleotide() or CalcMolWeightPoly() for implementation.</remarks>
        public static decimal CalcMolWeight(ISequence s)
        {
            var st = s.SequenceType;
            var seq = s.Strand;
            switch (st)
            {
                case SequenceEnums.SequenceType.DNA:
                    return CalcMolWeightNucleotide(seq);

                case SequenceEnums.SequenceType.RNA:
                    return CalcMolWeightNucleotide(seq);

                case SequenceEnums.SequenceType.Polypeptide:
                    return CalcMolWeightPoly(seq);

                default:
                    return 0;
            }
        }


        public static decimal CalcMolWeightCodon(OrfDictionary oDict)
        {

            return 0; //Not yet implemented
        }


        /// <summary>
        /// PRivate Helper Method CalcMolWeightNucleotide - Called by CalcMolWeight(). Parses the input sequence string and 
        ///     calculates the molecular weight of the sequence, in Daltons.
        /// </summary>
        /// <param name="s">String - the input sequence strand.</param>
        /// <returns>Decimal - the molecular weight of the sequence, in Daltons</returns>
        /// <remarks>This method is part of the internal implementation and should be called directly. This method does not throw Exceptions.</remarks>
        private static decimal CalcMolWeightNucleotide(string s)
        {

            var dn = new decimal();

            for (int i = 0; i < s.Length - 1; i++)
            {
                switch (s.Substring(i, 1))
                {
                    case "A":
                        dn += 297.21m;
                        break;
                    case "C":
                        dn += 273.19m;
                        break;
                    case "T":
                        dn += 288.63m;
                        break;
                    case "G":
                        dn += 313.21m;
                        break;

                    case "U":
                        dn += 112.09m;
                        break;

                    default:
                        break;
                }
            }

            return dn;

        }


        /// <summary>
        /// PRivate Helper Method CalcMolWeightPoly - Called by CalcMolWeight(). Parses the input sequence string and 
        ///     calculates the molecular weight of the sequence, in Daltons.
        /// </summary>
        /// <param name="s">String - the input sequence strand.</param>
        /// <returns>Decimal - the molecular weight of the sequence, in Daltons</returns>
        /// <remarks>This method is part of the internal implementation and should be called directly. This method does not throw Exceptions.</remarks>
        private static decimal CalcMolWeightPoly(string s)
        {
            var dp = new decimal();
            var aa = AminoAcids.AminoMolecularWeights();

            for (int i = 0; i < s.Length - 1; i++)
            {
                foreach (var a in aa)
                {
                    if (s.Substring(i, 1) == a.Key)
                        dp += a.Value;
                }
            }
            return dp;
        }

        // Not yet implemented
        private static decimal[] CalcCodonMolWeight(string s)
        {
            var len = (s.Length / 3);
            var dArray = new decimal[len];
            // TODO: Complete implementation of CalcCodonMolWeight(string s)

            return dArray;
        }

    }





}
