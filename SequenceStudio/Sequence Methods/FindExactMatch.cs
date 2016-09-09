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
        /// Internal Method FindExactMatches - This is the internal method that is called by FindMatches(). 
        /// This method determines of the Strands of the two input sequences are identical, then returns the result to FindMatches().
        ///     IF they are identical the result will be the MAtch instance with all the metadata.
        ///     If they are not the result will be a Match instance with MatchType = Empty.
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
        /// <remarks>Although this method could just return a Boolean, it needs to comply with the 
        ///     delegate signature. The IMatch object is light weight and performance is not an issue with Match.</remarks>
        internal static IMatch FindExactMatches(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold)
        {
            var matches = new Dictionary<int, int>();


            // TODO: Implement 'FindExactMatches()' 

            return new Match(SequenceEnums.MatchType.ExactMatch, template.SequenceType, to, po, 
                template.StrandHash, pattern.StrandHash, threshold, matches);
        }
    }
}
