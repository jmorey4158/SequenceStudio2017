using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract]
    public class OrfList
    {
        #region Constructors

        public OrfList() { }

        public OrfList(DNA d)
        {
            Source = d.StrandHash;
            List = SequenceMethods.FindOrfs(d);
        }

        public OrfList(RNA r)
        {
            Source = r.StrandHash;
            List = SequenceMethods.FindOrfs(r);
        }

        #endregion

        #region Data Members
        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public List<KeyValuePair<int, int>> List { get; set; }

        #endregion
    }


    [DataContract]
    public class OrfDictionary
    {
        #region Constructors

        public OrfDictionary() { }

        public OrfDictionary(OrfList o)
        {
            Source = o.Source;
            Dictionary = SequenceMethods.PopulateOrfs(o);
        }

        #endregion

        #region Data Members
        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public Dictionary<int, string> Dictionary { get; set; }

        #endregion
    }

}
