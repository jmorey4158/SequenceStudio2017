using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract(Name = "eSearchResult", Namespace = "")]
    public class NcbiSearchResult
    {

        public NcbiSearchResult() { }

        #region Data Members
        public NcbiEnums.Databases DB { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public int RetMax { get; set; }

        [DataMember]
        public int RetStart { get; set; }

        [DataMember]
        public List<int> IdList { get; set; }
        #endregion
    }
}
