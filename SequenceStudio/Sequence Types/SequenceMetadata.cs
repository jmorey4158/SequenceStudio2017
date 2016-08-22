using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract]
    public abstract class SequenceMetadata : ISequenceMetadata
    {


        public SequenceMetadata(ISequence seq)
        {
            StrandHash = seq.StrandHash;
            StrandLength = seq.Strand.Length;
            MolecularWeight = SequenceMethods.GetMolecularWeight(seq);
            ResidueStatistics = SequenceMethods.GetResidueStatistics(seq);
        }

        #region Data Members
        [DataMember]
        public Dictionary<int, string> ResidueStatistics { get; private set; }

        [DataMember]
        public decimal MolecularWeight { get; private set; }

        [DataMember]
        public int StrandLength { get; private set; }

        [DataMember]
        public string StrandHash { get; private set; }

        #endregion
    }
}
