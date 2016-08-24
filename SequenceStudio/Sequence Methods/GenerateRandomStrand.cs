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
        /// Help Method GenerateRandomStrand - This method creates a valid ISequence-compliant random Strand (string).
        /// </summary>
        /// <param name="length">Int - The length of the random Strand.</param>
        /// <param name="type" cref="SequenceTypes">SequenceType - The type of sequence to create (e.g. DNA, RNA, Polypeptide, or ConsensusSequence.</param>
        /// <returns>String - the ISequence-compliant sequence Strand.</returns>
        public static string GenerateRandomStrand(int length, SequenceEnums.SequenceType type)
        {
            if (length < 0)
                length = Math.Abs(length);

            if (length == 0)
                throw new SequenceException("Strand length must be greater than 0 residues long.");

            var pattern = "";

            switch(type)
            {
                case (SequenceEnums.SequenceType.DNA):
                    pattern = RegexePatterns.pos_regexDNA.Substring(1, (RegexePatterns.pos_regexDNA.Length - 2));
                    break;

                case (SequenceEnums.SequenceType.RNA):
                    pattern = RegexePatterns.pos_regexRNA.Substring(1, (RegexePatterns.pos_regexRNA.Length - 2));
                    break;

                case (SequenceEnums.SequenceType.Polypeptide):
                    pattern = "ACDEFGHIKLMNPQRSTVWY";
                    break;

                case (SequenceEnums.SequenceType.ConsensusDNA):
                    pattern = "ACTGN*_";
                    break;

                default:
                    throw new SequenceException("The specified SequenceType does not match any known SequenceType.");
            }

            var sb = new StringBuilder();

            Random rnd = new Random();
            int r;

            for (int i = 1; i <= length; i++)
            {
                r = rnd.Next(0, pattern.Length);
                sb.Append(pattern.Substring(r, 1));
            }

            return sb.ToString();

        }

    }

}