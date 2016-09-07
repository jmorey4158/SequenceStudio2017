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

            if (SequenceMethods.ValidateSequence(seq, type))
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



        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Sequence ID: {StrandHash}\nStrand Length: {Strand.Length}\nSequence Type: {SequenceType}\nSequence Origin: {SequenceOriginType}");

            return sb.ToString();

        }

        #endregion
    }
}
