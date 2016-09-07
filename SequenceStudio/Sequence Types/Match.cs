using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public class Match : IMatch
    {
        #region Constructors
        public Match(SequenceEnums.MatchType mt, SequenceEnums.SequenceType st, SequenceEnums.SequenceOriginType to,
            SequenceEnums.SequenceOriginType po, string tId, string pId, int t, Dictionary<int, int> ms)
        {

            if(string.IsNullOrEmpty(tId) || string.IsNullOrEmpty(pId))
                throw new SequenceException(string.Format("The specified 'strand' and the 'pattern' must not be null or empty"));

            if(tId == pId)
                throw new SequenceException(
                    string.Format("The specified 'strand' and the 'pattern' must not be the same Sequence"));

            if(ms == null | ms.Count == 0)
                throw new SequenceException(
                    string.Format("The specified 'matches list' must not be null or empty"));

            if(t > 100 | t <= 0)
                throw new SequenceException(
                    string.Format("The specified 'threshold' must be 1 to 100"));

            MatchType = mt;
            SequenceType = st;
            TemplateID = tId;
            PatternID = pId;
            Threshold = t;
            Matches = ms;
            ID = SequenceMethods.GetMatchHash(mt, st, tId, pId, t);

        }
        #endregion


        #region Data Members

        [DataMember]
        public string ID { get; private set; }

        [DataMember]
        public SequenceEnums.MatchType MatchType { get; }

        [DataMember]
        public SequenceEnums.SequenceType SequenceType { get; }

        [DataMember]
        public SequenceEnums.SequenceOriginType TemplateType { get; }

        [DataMember]
        public SequenceEnums.SequenceOriginType PatternType { get; }

        [DataMember]
        public string TemplateID { get;}

        [DataMember]
        public string PatternID { get; }

        [DataMember]
        public int Threshold { get; }

        [DataMember]
        public Dictionary<int, int> Matches { get; }

        #endregion
    }
}
