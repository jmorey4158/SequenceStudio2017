using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    /// <summary>
    /// Class instances are passed to GetESearchResults(ESearchQuery). 
    /// ESearchQuery.Query Property is used to call NCBI ESearch Web API.
    /// If the ESearchQuery.Term Property is malformed a the Method will return an empty NcbiSearchResult.
    /// Class instances can be saved to the Database and Seriealized or Deserialized.
    /// </summary>
    /// <seealso cref="GetESearchResults"/>
    [DataContract]
    public class ESearchQuery
    {
        #region Constructors
        public ESearchQuery() { }
        public ESearchQuery(NcbiEnums.Databases db, string term, 
            NcbiEnums.Fields field = NcbiEnums.Fields.EMPTY,
            NcbiEnums.RetMode retmode = NcbiEnums.RetMode.Xml,
            NcbiEnums.ESearchRetType rettype = NcbiEnums.ESearchRetType.eUtility,
            int retmax = 20,
            int retstart = 0)
        {
            DbEnum = db;

            #region switch Database
            switch (db)
            {
                case NcbiEnums.Databases.Nucleotide:
                    DB = NcbiContstants.Databases.Nucleotide;
                    break;

                case NcbiEnums.Databases.Gene:
                    DB = NcbiContstants.Databases.Gene;
                    break;

                case NcbiEnums.Databases.Genome:
                    DB = NcbiContstants.Databases.Genome;
                    break;

                case NcbiEnums.Databases.Protein:
                    DB = NcbiContstants.Databases.Protein;
                    break;

                case NcbiEnums.Databases.SNP:
                    DB = NcbiContstants.Databases.SNP;
                    break;

                case NcbiEnums.Databases.Taxanomy:
                    DB = NcbiContstants.Databases.Taxonomy;
                    break;

                default:
                    throw new SequenceException(
                        string.Format("The input NcbiEnums.Databases did not match any known database type."));
            }
            #endregion

            #region switch RetMode
            switch (retmode)
            {
                case NcbiEnums.RetMode.Xml:
                    RetMode = NcbiContstants.ESearchRetMode.Xml;
                    break;

                case NcbiEnums.RetMode.JSON:
                    RetMode = NcbiContstants.ESearchRetMode.Json;
                    break;

                default:
                    throw new SequenceException(
                        string.Format("The input NcbiEnums.RetMode did not match any known database type."));
            }
            #endregion

            #region switch RetType
            switch (rettype)
            {
                case NcbiEnums.ESearchRetType.eUtility:
                    RetType = NcbiContstants.ESearchRetType.Util;
                    break;

                case NcbiEnums.ESearchRetType.CountOnly:
                    RetType = NcbiContstants.ESearchRetType.Count;
                    break;

                default:
                    throw new SequenceException(
                        string.Format("The input NcbiEnums.RetType did not match any known database type."));

            }
            #endregion

            #region switch Field
            switch (field)
            {
                case NcbiEnums.Fields.EMPTY:
                    Field = "";
                    break;

                case NcbiEnums.Fields.Property:
                    Field = NcbiContstants.Fields.Property;
                    break;

                case NcbiEnums.Fields.MolecularWeight:
                    Field = NcbiContstants.Fields.MolecularWeight;
                    break;

                case NcbiEnums.Fields.Organsim:
                    Field = NcbiContstants.Fields.Organsim;
                    break;

                case NcbiEnums.Fields.Length:
                    Field = NcbiContstants.Fields.Length;
                    break;

                case NcbiEnums.Fields.ProteinName:
                    Field = NcbiContstants.Fields.ProteinName;
                    break;

                case NcbiEnums.Fields.Accession:
                    Field = NcbiContstants.Fields.Accession;
                    break;

                default:
                    throw new SequenceException(
                        string.Format("The input NcbiEnums.Fields did not match any known database type."));
            }
            #endregion

            RetMax = retmax;
            if (retmax > NcbiContstants.Defaults.RetMax)
                RetMax = NcbiContstants.Defaults.RetMax;

            RetStart = retstart;
            if (retstart > retmax)
                RetStart = NcbiContstants.Defaults.RetStart;

            #region Parse Term
            //Put Regex.IsMatch(badthings) here
            Term = term;

            #endregion

            #region Build Query
            var sb = new StringBuilder();
            sb.Append(NcbiContstants.BaseUrls.ESearch);
            sb.Append(DB);
            sb.Append("&term=" + Term);
            sb.Append(Field);
            sb.Append("&retstart=" + RetStart);
            sb.Append("&retmax=" + RetMax);
            sb.Append(RetType);
            sb.Append(RetMode);

            sb.Replace("[", "%5b");
            sb.Replace("]", "%5d");
            sb.Replace(" ", "+");

            Query = sb.ToString();
            #endregion
        }
        #endregion

        #region Data Members
        [DataMember]
        public string Query { get; private set; }

        [DataMember]
        public string DB { get; private set; }

        [DataMember]
        public NcbiEnums.Databases DbEnum { get; set; }

        [DataMember]
        public string Term { get; private set; }

        [DataMember]
        public string RetType { get; private set; }

        [DataMember]
        public string RetMode { get; private set; }

        [DataMember]
        public string Field { get; private set; }

        [DataMember]
        public int RetMax { get; private set; }

        [DataMember]
        public int RetStart { get; private set; }
        #endregion
    }
}
