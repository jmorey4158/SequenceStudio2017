using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static partial class SequenceMethods
    {
        public static IMatch GetDbMatch(string id)
        {
            //This is mocked up to get me by for now. Later, add DatabaseMethods to get real stuff.
            var mt = SequenceEnums.MatchType.ExactMatch;
            var tt = SequenceEnums.SequenceType.DNA;
            var to = SequenceEnums.SequenceOriginType.Manual;
            var po = SequenceEnums.SequenceOriginType.Manual;
            var temID = "TempID";
            var patID = "patID";
            var t = 100;
            var matches = new Dictionary<int, int>();
            matches.Add(0, 0);


            // TODO: Add implementation to search DB for the same Match.ID.


           return new Match(mt, tt, to, po, temID, patID, t, matches);
        }
    }
}