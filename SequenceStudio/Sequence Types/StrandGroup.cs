using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract]
    public sealed class StrandGroup
    {
        List<string> g = new List<string>();

        #region Constructors
        public StrandGroup(DNA d)
        {
            Reverse = SequenceMethods.GetComplimentStrand(d);
            Compliment = SequenceMethods.GetReverseStrand(d);
            ReverseCompliment = SequenceMethods.GetReverseComplimentStrand(d);
            Source = d;

            g.Add(Reverse);
            g.Add(Compliment);
            g.Add(ReverseCompliment);
        }
        #endregion


        #region Data Members

        [DataMember]
        public List<string> Group { get { return g; } }

        [DataMember]
        public string Compliment { get; }

        [DataMember]
        public string Reverse { get; }

        [DataMember]
        public string ReverseCompliment {get;}

        [DataMember]
        public DNA Source { get; }

        #endregion


        #region Methods
        public override string ToString()
        {
            return string.Format("Source Strand: {0}\nCompliment: {1}\nReverse: {2}\nRevese Compliment: {3}", Source.StrandHash,
                Compliment, Reverse, ReverseCompliment);
        }
        #endregion
    }
}
