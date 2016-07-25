using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    [DataContract]
    public class DbLink : INcbiDbLink
    {
        public DbLink() { }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Menu { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string DbTo { get; set; }
    }


    [DataContract]
    public class DbInfo : INcbiDbInfo
    {
        public DbInfo() { }

        [DataMember]
        public string DbName { get; set; }

        [DataMember]
        public string MenuName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string DbBuild { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public DateTime LastUpdate { get; set; }

        [DataMember]
        public List<DbField> FieldList { get; set; }

        [DataMember]
        public List<DbLink> LinkList { get; set; }
    }


    [DataContract]
    public class DbField : INcbiDbField
    {
        public DbField(){}

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int TermCount { get; set; }

        [DataMember]
        public bool IsDate { get; set; }

        [DataMember]
        public bool SingleToken { get; set; }

        [DataMember]
        public bool Hierarchy { get; set; }

        [DataMember]
        public bool IsHidden { get; set; }
    }


    [DataContract]
    public class DbField2 : INcbiDbField2
    {
        public DbField2() { }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int TermCount { get; set; }

        [DataMember]
        public bool IsDate { get; set; }

        [DataMember]
        public bool SingleToken { get; set; }

        [DataMember]
        public bool Hierarchy { get; set; }

        [DataMember]
        public bool IsHidden { get; set; }

        [DataMember]
        public bool IsTruncatable { get; set; }

        [DataMember]
        public bool IsRangable { get; set; }

    }
}
