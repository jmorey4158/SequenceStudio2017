using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        public delegate IMatch FindMatchesDelegate(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold);


        public static IMatch FindMatches(ISequence template, ISequence pattern,
            SequenceEnums.SequenceOriginType to, SequenceEnums.SequenceOriginType po, int threshold, SequenceEnums.MatchType mt)
        {

            #region Validate Inputs

            var ts = template.Strand;
            var ps = pattern.Strand;
            var tt = template.SequenceType;
            var pt = pattern.SequenceType;
            if (threshold > 100)
                threshold = 100;
            if (threshold < 1)
                threshold = 1;

            //Do the two SequenceTypes match? Continue : throw SequenceException
            if (tt != pt)
                throw new SequenceException(string.Format("The specified 'template' SequenceType {0} did not match the specified 'pattern' SequenceType {1}.",
                    tt.ToString(), pt.ToString()));

            //Does this Match already exist? Get Match from Matches DB : Continue 
            var hash = GetMatchHash(mt, tt, template.StrandHash, pattern.StrandHash, threshold);
            if (CompareIMatchToDb(hash))
                return GetDbMatch(hash);

            //Does the 'pattern' match anywhere on the 'template'? Continue : Return a Match with MatchType = Empty.
            if (template.Strand.IndexOf(pattern.Strand) == -1)
                return new Match(SequenceEnums.MatchType.Empty, tt, to, po, template.StrandHash, pattern.StrandHash, threshold, new Dictionary<int, int>());

            #endregion

            #region Call Delegate Methods

            // Use MatchType to call correct delegate (defined in another CS file).
            switch (mt)
            {
                case (SequenceEnums.MatchType.ExactMatch):
                    FindMatchesDelegate exact = FindExactMatches;
                    return exact(template, pattern, to, po, 100);//Set threshold = 100 on ExactMatches

                case (SequenceEnums.MatchType.PercentageMatch):
                    FindMatchesDelegate percentage = FindPercentageMatches;
                    return percentage(template, pattern, to, po, threshold);

                case (SequenceEnums.MatchType.ContiguousMatch):
                    FindMatchesDelegate contig = FindContiguousMatches;
                    return contig(template, pattern, to, po, threshold);
               

                default:
                    throw new SequenceException(string.Format("The specified Enums.MatchType {0} was not recognized.", mt));
                    //In theory, default should never be hit. This is here to make sure. 


            #endregion

            }
        }
    }
}
