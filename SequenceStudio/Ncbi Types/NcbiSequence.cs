using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    /// <summary>
    /// Class to represent the Sequence data returned from NCBI EFetch Web API calls.
    /// This class can be Serialized, Deserialized, and stored in the Database.
    /// </summary>
    [DataContract]
    public sealed class NcbiSequence : Sequence
    {
        #region Constructors
        public NcbiSequence() { }

        public NcbiSequence(FastARecord fasta, SequenceEnums.SequenceType type, 
            SequenceEnums.SequenceOriginType org = SequenceEnums.SequenceOriginType.Manual)
            : base(fasta.Sequence, type, SequenceEnums.SequenceOriginType.NCBI)
        {
            UniqueID = fasta.UniqueID;
            AccessionVersion = fasta.AccessionVersion;
            TaxanomicID = fasta.TaxanomicID;
            OrganismName = fasta.OrganismName;
            Description = fasta.Description;
            SequenceLength = fasta.SequenceLength;
            SeqID = fasta.SeqID;
        }

        #endregion


        #region Extended Data Members

        //This value is the Unique Identifier in the NCBI Entrez Database.
        //Here we use the StrandHash value for all ISequence classes
        [DataMember]
        public int UniqueID { get; set; }

        [DataMember]
        public string AccessionVersion { get; set; }

        //The older FastA results do not include this tag. the Newer ones do. Included for consistency. 
        [DataMember]
        public string SeqID { get; set; }

        [DataMember]
        public int TaxanomicID { get; set; }

        [DataMember]
        public string OrganismName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int SequenceLength { get; set; }

        #endregion


        #region Methods
        public override string ToString()
        {
            return string.Format("UID: {0}\nAccession: {1}\nTaxanomic ID: {2}\nOrganism Name: {3}\nDescription: {4}\nLength: {5}\nSequenceType: {6}\nStrand Hash: {7}\nSequence: {8}"
                ,UniqueID, AccessionVersion, TaxanomicID, OrganismName, Description, 
                SequenceLength, SequenceType, StrandHash, Strand);
        }
        #endregion
    }
}
