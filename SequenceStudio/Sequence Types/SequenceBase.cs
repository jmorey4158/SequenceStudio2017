using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SequenceStudio
{
    [DataContract]
    public abstract partial class Sequence : ISequence
    {

        #region Constructors
        public Sequence() { }
        public Sequence(string seq, SequenceEnums.SequenceType type, SequenceEnums.SequenceOriginType otype = SequenceEnums.SequenceOriginType.Manual, bool isUnique = false)
        {

            if (ValidateSequence(seq, type))
            {
                if (isUnique)
                    if(SequenceMethods.CompareISequenceToDb(SequenceMethods.GetISequenceHash(seq)))
                        throw new SequenceException(string.Format("You requested that the specified 'sequence' be unique, however, the specified 'sequence' already exists."));

                Strand = seq;

                StrandHash = SequenceMethods.GetISequenceHash(seq);

                SequenceType = type;

                SequenceOriginType = otype;
            }
            else
            {
                throw new SequenceException(string.Format("The input strand is not a valid {0} Sequence.", type.ToString()));
            }

        }

        #endregion


        #region Data Members

        [DataMember]
        /// <summary>
        /// The Enumeration is derived from the NCBI enumeration property. It is used so that identification
        /// of sequences with the NCBI databases can be made.
        /// </summary>
        public string Strand { get; set; }

        [DataMember]
        /// <summary>
        /// The Enumeration is derived from the NCBI enumeration property. It is used so that identification
        /// of sequences with the NCBI databases can be made.
        /// </summary>
        [Key]
        public string StrandHash { get; set; }

        [DataMember]
        /// <summary>
        /// 
        /// </summary>
        public SequenceEnums.SequenceType SequenceType { get;  set; }

        [DataMember]
        /// <summary>
        /// 
        /// </summary>
        public SequenceEnums.SequenceOriginType SequenceOriginType { get;  set; }

        #endregion


        #region Methods

        /// <summary>
        /// Validates that the input sequence is a valid Type of sequence.
        /// </summary>
        /// <param name="s">String - The input sequence string to validate.</param>
        /// <param name="p">String - the SequenceType to validate the input string against.</param>
        /// <returns>Boolean - true if the validation passed; false if not.</returns>
        /// <remarks>this method is overridden in child classes that use type-specific patterns.</remarks>
        /// <exception cref="SequenceException">A SequenceException is throw if the input string does not comply with the SequenceType.</exception>
        public bool ValidateSequence(string s, SequenceEnums.SequenceType st)
        {
             if (string.IsNullOrWhiteSpace(s))
                throw new SequenceException("The input 'strand' may not be empty or null.");

             //Get the negative match pattern for the SequenceType
            var regex = new Regex(GetRegex(st));

            //If any character in the input string matches the negative pattern then return 'false' which throws a SequenceException.
            if (regex.IsMatch(s))
                return false;

            //If the input string does NOT match the negative pattern then return 'true' and continue to instantiate the ISequence class.
            return true;
        }


        /// <summary>
        /// Returns the negative Regex string for the corresponding Enums.SequenceType. 
        /// The regex string is used by the ValidateSequence method to create the Regex(type).  
        /// </summary>
        /// <param name="st">Enums.SequenceType - tells the method which RegexePatterns enum to return.</param>
        /// <returns>String that represents the RegexePatterns. </returns>
        protected string GetRegex(SequenceEnums.SequenceType st)
        {
            switch(st)
            {
                case (SequenceEnums.SequenceType.DNA):
                    return RegexePatterns.neg_regexDNA;
 
                case (SequenceEnums.SequenceType.RNA):
                    return RegexePatterns.neg_regexRNA;

                case (SequenceEnums.SequenceType.Polypeptide):
                    return RegexePatterns.neg_regexAAshort;

                case (SequenceEnums.SequenceType.ConsensusDNA):
                    return RegexePatterns.neg_regexConsensusDNA;

                default:
                    throw new SequenceException("The specified Sequence Type does not match any known patterns.");
            }

        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Sequence ID: {StrandHash}\nStrand Length: {Strand.Length}\nSequence Type: {SequenceType}\nSequence Origin: {SequenceOriginType}");

            return sb.ToString();

        }

        #endregion
    }
}
