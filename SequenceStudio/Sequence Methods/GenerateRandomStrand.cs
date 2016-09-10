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
            // If they input -1234 get Abs value of 1234
            if (length < 0)
                length = Math.Abs(length);

            // If they input 0 throw a SequenceException telling them so
            if (length == 0)
                throw new SequenceException("Strand length must be greater than 0 residues long.");

            var pattern = "";

            switch(type)
            {
                case (SequenceEnums.SequenceType.DNA):
                    pattern = "ACTG";
                    break;

                case (SequenceEnums.SequenceType.RNA):
                    pattern = "ACUG";
                    break;

                case (SequenceEnums.SequenceType.Polypeptide):
                    pattern = "ACDEFGHIKLMNPQRSTVWY";
                    break;

                case (SequenceEnums.SequenceType.ConsensusDNA):
                    pattern = "ACTGN*_";
                    break;

                default:
                    break;
            }

            var sb = new StringBuilder();

            Random rnd = new Random();
            int r;

            // This is the loop that actually creates the Strand.
            for (int i = 1; i <= length; i++)
            {
                r = rnd.Next(0, pattern.Length);
                sb.Append(pattern.Substring(r, 1));
            }

            return sb.ToString();

        }



        /// <summary>
        /// Help Method GenerateRandomDopedStrand - This method creates a valid ISequence-compliant random Strand (string).
        ///     You can 'dope' the strand by specifying a valid ISequence-compliant sequence string. For example, if you want 
        ///     to create a random strand with twice as many 'GC' residues than 'AT' residues specify the 'Pattern' 'ATGCGC'.
        /// </summary>
        /// <param name="length">Int - The length of the random Strand.</param>
        /// <param name="type" cref="SequenceTypes">SequenceType - The type of sequence to create (e.g. DNA, RNA, Polypeptide, or ConsensusSequence.</param>
        /// <param name="pattern">A valid ISequence-compliant sequence string that specifies the ratio of the residues in the returned sequence.</param>
        /// <returns>String - the ISequence-compliant sequence Strand.</returns>
        public static string GenerateRandomDopedStrand(int length, SequenceEnums.SequenceType type, string pattern)
        {
            // If they input -1234 get Abs value of 1234
            if (length < 0)
                length = Math.Abs(length);

            // If they input 0 throw a SequenceException telling them so
            if (length == 0)
                throw new SequenceException("Strand length must be greater than 0 residues long.");



            if (!String.IsNullOrEmpty(pattern))
            {
                switch (type)
                {
                    case (SequenceEnums.SequenceType.DNA):
                        if (!SequenceMethods.ValidateSequence(pattern, SequenceEnums.SequenceType.DNA))
                            throw new Exception("The 'pattern' is not a valid DNA sequence.");
                        break;


                    case (SequenceEnums.SequenceType.RNA):
                        if (!SequenceMethods.ValidateSequence(pattern, SequenceEnums.SequenceType.RNA))
                            throw new Exception("The 'pattern' is not a valid RNA sequence.");
                        break;


                    case (SequenceEnums.SequenceType.Polypeptide):
                        if (!SequenceMethods.ValidateSequence(pattern, SequenceEnums.SequenceType.Polypeptide))
                            throw new Exception("The 'pattern' is not a valid Polypeptide sequence.");
                        break;


                    default:
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case (SequenceEnums.SequenceType.DNA):
                        pattern = "ACTG";
                        break;

                    case (SequenceEnums.SequenceType.RNA):
                        pattern = "ACUG";
                        break;

                    case (SequenceEnums.SequenceType.Polypeptide):
                        pattern = "ACDEFGHIKLMNPQRSTVWY";
                        break;

                    case (SequenceEnums.SequenceType.ConsensusDNA):
                        pattern = "ACTGN*_";
                        break;

                    default:
                        break;
                }
            }

            var sb = new StringBuilder();

            Random rnd = new Random();
            int r;

            // This is the loop that actually creates the Strand.
            for (int i = 1; i <= length; i++)
            {
                r = rnd.Next(0, pattern.Length);
                sb.Append(pattern.Substring(r, 1));
            }

            return sb.ToString();

        }

    }

}