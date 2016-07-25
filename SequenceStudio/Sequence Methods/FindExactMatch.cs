using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        public static IMatch FindExactMatches(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold)
        {


            var matches = new Dictionary<int, int>();

            return new Match(SequenceEnums.MatchType.ExactMatch, template.SequenceType, to, po, 
                template.StrandHash, pattern.StrandHash, threshold, matches);
        }
    }
}
