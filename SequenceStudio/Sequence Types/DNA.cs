using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    
    public sealed class DNA : Sequence
    {
        public DNA() { }

        public DNA(string s, SequenceEnums.SequenceOriginType org = SequenceEnums.SequenceOriginType.Manual) 
            : base(s, SequenceEnums.SequenceType.DNA, org){}
    }
}
