using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public class Substrand : Sequence
    {
        #region Constructors
        public Substrand() { }

        public Substrand(string s, SequenceEnums.SequenceType type, SequenceEnums.SequenceOriginType org, string p, int l) 
            : base(s, SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Substrand)
        {
            ParentSequence = p;
            Locus = l;
            Length = s.Length;
        }

        public Substrand(ISequence seq, int locus, int len) 
            : base(seq.Strand.Substring(locus, len), seq.SequenceType, SequenceEnums.SequenceOriginType.Substrand)
        {
            ParentSequence = seq.StrandHash;
            Locus = locus;
            Length = len;
        }
        #endregion


        #region Data Members
        [DataMember]
        public string ParentSequence { get; set; }

        [DataMember]
        public int Locus { get; set; }

        [DataMember]
        public int Length { get; set; }

        #endregion


    }
}
