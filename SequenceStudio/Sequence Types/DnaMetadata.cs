using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract]
    public sealed class DnaMetadata : SequenceMetadata
    {

        public DnaMetadata(DNA d) : base(d)
        {
            Transcript = SequenceMethods.GetTranscript(d);
        }

        [DataMember]
        public string Transcript { get; private set; }

    }
}
