using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    /// <summary>
    /// Used by various NcbiMethods to ensure consitancy and code stability.
    /// Const and Enums that represent important NCBI Web API values.
    /// </summary>
    public static class NcbiContstants
    {
        public static class Databases
        {
            public const string Nucleotide = "db=nucleotide";
            public const string Gene = "db=gene";
            public const string Genome = "db=geneome";
            public const string Protein = "db=protein";
            public const string SNP = "db=snp";
            public const string Taxonomy = "db=taxonomy";
        }


        public static class ESearchRetType
        {
            public const string Util = "&rettype=util";
            public const string Count = "&rettype=count";
        }

        public static class EFetchRetTypeMode
        {
            public const string UidList = "&rettype=uilist&retmode=xml";
            public const string Alignment = "&rettype=alignmentscores&retmode=xml";
            public const string TinySeqFastA = "&rettype=fasta&retmode=xml";
            public const string Native = "&rettype=native&retmode=xml";
            public const string GBSeq = "&rettype=gp&retmode=xml";
            public const string INSDSeq = "&rettype=gpc&retmode=xml";
            public const string SNP = "&rettype=&retmode=xml";
            public const string TaxIdList = "&rettype=uilist&retmode=xml";
        }

        public static class ESearchRetMode
        {
            public const string Xml = "&retmode=xml";
            public const string Json = "&retmode=json";
        }

        public static class Fields
        {
            public const string Property = "[prop]";
            public const string MolecularWeight = "[molecular+weight]";
            public const string Organsim = "[organism]";
            public const string Length = "[Sequence+Length]";
            public const string ProteinName = "[Protein+Name]";
            public const string Accession = "[Accession]";
        }

        public static class BaseUrls
        {
            public const string ESearch = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?";
            public const string EFetch = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/efetch.fcgi?";
            public const string ESummary = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?";
            public const string EInfo = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/einfo.fcgi?";
            public const string EPost = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/epost.fcgi?";
            public const string ELink = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/elink.fcgi?";
            public const string ESpell = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/espell.fcgi?";


        }

        public static class Defaults
        {
            public static int RetMax = 1000;
            public static int RetStart = 1;
        }
    }


    public static class NcbiEnums
    {
        public enum Databases
        {
            Nucleotide, Gene, Genome, Protein, SNP, Taxanomy
        }

        public enum ESearchRetType
        {
            eUtility, CountOnly
        }

        public enum EFetchRetTypeMode
        {
            UidList, Alignment, TinySeqFastA, Native, GBSeq, INSDSeq, SNP
        }

        public enum RetMode
        {
            Xml, JSON
        }

        public enum Fields
        {
            Property, MolecularWeight, Organsim, Length, ProteinName, Accession, EMPTY
        }




    }

}

