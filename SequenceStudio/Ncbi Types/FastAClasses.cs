using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SequenceStudio
{
    [DataContract(Name = "TSeq", Namespace = "")]
    public class FastARecord : IFastaRecord
    {
        private string _seq;
        //Only this c'tor is allowed and is only called in the Golden Path.
        //Don't want any malformed or invalid FastaRecord instances
        public FastARecord() { }

        #region DataMembers

        [DataMember(Name = "TSeq_seqtype", Order = 0)]
        public string SequenceType { get; set; }

        [Key]
        [DataMember(Name = "TSeq_gi", Order = 1)]
        public int UniqueID { get; set; }

        [DataMember(Name = "TSeq_accver", Order = 2)]
        public string AccessionVersion { get; set; }

        [DataMember(Name = "TSeq_sid", Order = 3)]
        public string SeqID { get; set; }

        [DataMember(Name = "TSeq_taxid", Order = 4)]
        public int TaxanomicID { get; set; }

        [DataMember(Name = "TSeq_orgname", Order = 5)]
        public string OrganismName { get; set; }

        [DataMember(Name = "TSeq_defline", Order = 6)]
        public string Description { get; set; }

        [DataMember(Name = "TSeq_length", Order = 7)]
        public int SequenceLength { get; set; }

        [DataMember(Name = "TSeq_sequence", Order = 8)]
        public string Sequence
        {
            get { return _seq; }
            set { _seq = value.ToUpper(); }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("UniqueID: {0}\nAccession Version: {1}\nSequenceType: {2}\nTaxanomic ID: {3}\nOrganism Name: {4}\nDescription: {5}\nSequence Length: {6}\nSequence: {7}",
                UniqueID, AccessionVersion, SequenceType, TaxanomicID, OrganismName, Description, SequenceLength, Sequence);
        }

        public static string ValidateInput(string seq)
        {
            if (!Regex.IsMatch(seq, RegexePatterns.neg_regexDNA))
                return SequenceTypes.DNA;

            if (!Regex.IsMatch(seq, RegexePatterns.neg_regexRNA))
                return SequenceTypes.RNA;

            if (!Regex.IsMatch(seq, RegexePatterns.neg_regexAAshort))
                return SequenceTypes.Poypeptide;

            if (!Regex.IsMatch(seq, RegexePatterns.neg_regexConsensusDNA))
                return SequenceTypes.ConsensusDNA;

            throw new SequenceException(string.Format("The input 'sequence' {0} does not match any known SequenceType.", seq));
        }
    }









    [DataContract]
    public class FastASet
    {
        public FastASet() { }

        public List<FastARecord> FastARecords { get; set; }
    }
}
