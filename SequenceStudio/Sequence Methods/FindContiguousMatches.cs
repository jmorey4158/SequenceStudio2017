using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        public static IMatch FindContiguousMatches(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold)
        {



            string tem = template.Strand;
            string pat = pattern.Strand;
            Dictionary<int, int> matches = new Dictionary<int, int>();
            int patternLength = pattern.Strand.Length;
            int cutoff = patternLength * (threshold / 100);
            int thisMatchRegion = 0;
            int lastRegionLocation = template.Strand.Length - patternLength;
            bool IsMatch = false;

            for (int regionLocation = 0; regionLocation <= lastRegionLocation; regionLocation++)
            {
                IsMatch = false;
                for (int patternLocation = 0; patternLocation <= patternLength - 1; patternLocation++)
                {
                    if (pat[patternLocation] == tem[regionLocation + patternLocation])
                    {
                        thisMatchRegion++;
                        IsMatch = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if ((IsMatch) && (thisMatchRegion >= cutoff))
                {
                    matches.Add(regionLocation + 1, thisMatchRegion);
                    thisMatchRegion = 0;
                }
            }



            return new Match(SequenceEnums.MatchType.ContiguousMatch, template.SequenceType, to, po, template.StrandHash, pattern.StrandHash, threshold, matches);
        }
    }
}
