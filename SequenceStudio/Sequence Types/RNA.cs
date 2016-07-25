using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public sealed class RNA : Sequence
    {
        public RNA(string s, SequenceEnums.SequenceOriginType org = SequenceEnums.SequenceOriginType.Manual) 
            : base(s, SequenceEnums.SequenceType.RNA, org){ }
    }
}
