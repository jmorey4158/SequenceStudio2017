using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        /// <summary>
        /// Internal Method FindContiguousMatches - This is the internal method that is called by FindMatches(). 
        /// This finds the matches of the Strands of the two input sequences, then returns the result to FindMatches().
        ///     There might be one or more matches. A 'match' is found when the two strands match at or above the 'threshold'
        ///     number of contiguous residue matches. the method 'slides' the two strands along each other to find all possible matches.
        ///     All matches are added to the List(Match), which returned as part of the IMatch instance.
        ///     If no matches at or above the 'threshold' are found the result will be a Match instance with MatchType = Empty.
        /// </summary>
        /// <param name="template">ISequence-compliant class instance - The strand that is being compared against.</param>
        /// <param name="pattern">ISequence-compliant class instance - The strand that is being compared with the 'template'.</param>
        /// <param name="to">SequenceOriginType - the type of the strands being compared. Both strands must 
        ///     be of the same SequenceOriginType.</param>
        /// <param name="po">SequenceOriginType - How the sequence was obtained. This is non-consequential metadata and 
        ///     will not affect the outcome of the method. The SequenceOriginType is for tracking and research purposes.</param>
        /// <param name="threshold">int - The minimum percentage of match between the two strands.
        ///     The way that 'threshold' is used is determined by the MatchType.</param>
        /// <returns cref="IMatch">IMatch-compliant class instance - The instance contains all the metadata to 
        ///     completely and distinctly represent the Match. </returns>
        internal static IMatch FindContiguousMatches(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold)
        {
            // TODO: Properly comment FindContiguousMatches()

            // TODO: Test FindContiguousMatches() implementation for accuracy and performance

            string tem = template.Strand; // The Strand of the 'template'.
            string pat = pattern.Strand;
            Dictionary<int, int> matches = new Dictionary<int, int>();
            int patternLength = pattern.Strand.Length;
            int cutoff = patternLength * (threshold / 100); // The 'threshold' must be translated into an int, the number of residue matches.
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

            return new Match(SequenceEnums.MatchType.ContiguousMatch, 
                template.SequenceType, to, po, template.StrandHash, pattern.StrandHash, threshold, matches);
        }
    }
}
