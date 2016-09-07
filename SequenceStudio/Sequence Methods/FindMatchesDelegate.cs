using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        // This is the method signature for all FindXXXXX methods. The metadata is important 
        //  to tracking what type of match it was, what type of sequence, and what specific sequences.
        public delegate IMatch FindMatchesDelegate(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold);

        /// <summary>
        /// Public Method FindMatches - This is the 'user-friendly' method that is called by external code. 
        /// This method determines which delegate should be called and calls it, then returns the result to the caller.
        /// 
        /// </summary>
        /// <param name="template">ISequence-compliant class instance - The strand that is being compared against.</param>
        /// <param name="pattern">ISequence-compliant class instance - The strand that is being compared with the 'template'.</param>
        /// <param name="to">SequenceOriginType - the type of the strands being compared. Both strands must 
        ///     be of the same SequenceOriginType.</param>
        /// <param name="po">SequenceOriginType - How the sequence was obtained. This is non-consequential metadata and 
        ///     will not affect the outcome of the method. The SequenceOriginType is for tracking and research purposes.</param>
        /// <param name="threshold">int - The minimum percentage of match between the two strands.
        ///     The way that 'threshold' is used is determined by the MatchType.</param>
        /// <param name="mt">MatchType - The type of matching requested.</param>
        /// <returns cref="IMatch">IMatch-compliant class instance - The instance contains all the metadata to 
        ///     completely and distinctly represent the Match. </returns>
        /// <remarks>This pattern was chosen to allow future extension and flexibility without forcing the
        ///  caller to adapt to changes. The caller simply calls this method and we do the right thing under the covers.</remarks>
        public static IMatch FindMatches(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold, SequenceEnums.MatchType mt)
        {
            // Make sure that the input values are correct.
            //  Also check if this Match already exists and if so, return it.
            #region Validate Inputs

            var ts = template.Strand;
            var ps = pattern.Strand;
            var tt = template.SequenceType;
            var pt = pattern.SequenceType;
            if (threshold > 100)
                threshold = 100;
            if (threshold < 1)
                threshold = 1;

            // Do the two SequenceTypes match? Continue : throw SequenceException
            if (tt != pt)
                throw new SequenceException(string.Format("The specified 'template' SequenceType {0} did not match the specified 'pattern' SequenceType {1}.",
                    tt.ToString(), pt.ToString()));

            // Does this Match already exist? Get Match from Matches DB : Continue 
            //  We use the hash of the Match metadata using SHA1. This way we can very quickly check if the Match 
            //  is already available. We do this because doing a Match can be resource-intensive
            //  and if we already have this Match, retrieving the Match from the Data Source 
            //  will probably be faster. If the Match already exists in the Data SOurce, return it.
            var hash = GetMatchHash(mt, tt, template.StrandHash, pattern.StrandHash, threshold);
            if (CompareIMatchToDb(hash))
                return GetDbMatch(hash);

            // Does the 'pattern' match anywhere on the 'template'? Continue : Return a Match with MatchType = Empty.
            // Match with a MatchType of Empty indicates there were no matches.
            if (template.Strand.IndexOf(pattern.Strand) == -1)
                return new Match(SequenceEnums.MatchType.Empty, tt, to, po, template.StrandHash, pattern.StrandHash, threshold, new Dictionary<int, int>());

            #endregion


            // If the Match metadata is valid and the Match does not already exist, 
            //  then find the Match, record it in the Data Source and return it.
            #region Call Delegate Methods

            // Use MatchType to call correct delegate (defined in another CS file).
            //  The beauty of this pattern is that we can add new Match methods, that
            //  follow the delegate signature, and a corresponding MatchType enum, 
            //  and consumers can use them without having to modify their existing code.
            //
            // The internally-called methods do all the work of finding the Match, recording the
            //  Match in the Data Source, and returning the Match to this calling method.
            switch (mt)
            {
                case (SequenceEnums.MatchType.ExactMatch):
                    FindMatchesDelegate exact = FindExactMatches;
                    return exact(template, pattern, to, po, 100);// Override threshold to 100 on ExactMatches

                case (SequenceEnums.MatchType.PercentageMatch):
                    FindMatchesDelegate percentage = FindPercentageMatches;
                    return percentage(template, pattern, to, po, threshold); // 'threshold' = percentage of total match

                case (SequenceEnums.MatchType.ContiguousMatch):
                    FindMatchesDelegate contig = FindContiguousMatches;
                    return contig(template, pattern, to, po, threshold); // 'threshold' = number of contiguous residues that must match
               
                    // We can add more delegate implementations here.

                default:
                    throw new SequenceException(string.Format($"The specified Enums.MatchType {0} was not recognized."));
                    //In theory, default should never be hit. This is here to make sure. 


            #endregion

            }
        }
    }
}
