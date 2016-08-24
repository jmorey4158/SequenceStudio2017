using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public static partial class SequenceMethods
    {
        public static decimal CalcMolWeight(ISequence s, SequenceEnums.SequenceType st)
        {
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

            return 0;
        }


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


        private static decimal[] CalcCodonMolWeight(string s)
        {
            var len = (s.Length / 3);
            var dArray = new decimal[len];


            return dArray;
        }

    }





}
