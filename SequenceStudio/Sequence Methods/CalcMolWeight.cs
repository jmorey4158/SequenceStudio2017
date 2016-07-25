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
                        decimal.Add(dn, (decimal)297.21);
                        break;
                    case "C":
                        decimal.Add(dn, (decimal)273.19);
                        break;
                    case "T":
                        decimal.Add(dn, (decimal)288.63);
                        break;
                    case "G":
                        decimal.Add(dn, (decimal)313.21);
                        break;

                    case "U":
                        decimal.Add(dn, (decimal)112.09);
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
                        decimal.Add(dp, a.Value);
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
