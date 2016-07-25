using System;
using System.Collections.Generic;


namespace SequenceStudio
{

    public interface INcbiDbInfo
    {
        string DbName { get; }
        string MenuName { get; }
        string Description { get; }
        string DbBuild { get; }
        int Count { get; }
        DateTime LastUpdate { get; }
    }


    public interface INcbiDbField
    {
        string Name { get; }
        string FullName { get; }
        string Description { get; }
        int TermCount { get; }
        bool IsDate { get; }
        bool SingleToken { get; }
        bool Hierarchy { get; }
        bool IsHidden { get; }
    }


    public interface INcbiDbField2
    {
        string Name { get; }
        string FullName { get; }
        string Description { get; }
        int TermCount { get; }
        bool IsDate { get; }
        bool SingleToken { get; }
        bool Hierarchy { get; }
        bool IsHidden { get; }
        bool IsTruncatable { get; }
        bool IsRangable { get; }
    }


    public interface INcbiDbLink
    {
        string Name { get; }
        string Menu { get; }
        string Description { get; }
        string DbTo { get; }
    }


    public interface INcbiSearchResult
    {
        int Count { get; }
        int RetMax { get; set; }
        int RetStart { get; set; }
        List<int> IdList { get; set; }
    }


    public interface IFastaRecord
    {
        string SequenceType { get; } //NCBI value: TSeq_seqtype
        int UniqueID { get; } //NCBI value: TSeq_gi
        string AccessionVersion { get; } //NCBI value: TSeq_accver
        int TaxanomicID { get; } //NCBI value: TSeq_taxid
        string OrganismName { get; } //NCBI value: TSeq_orgname
        string Description { get; } //NCBI value: TSeq_defline
        int SequenceLength { get; } //NCBI value: TSeq_length
        string Sequence{ get; } //NCBI value: TSeq_sequence
    }

}
