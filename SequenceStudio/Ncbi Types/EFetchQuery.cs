using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    /// <summary>
    /// Class instances are passed to GetEFetchResults(EFetchQuery). 
    /// EFetchQuery.Query Property is used to call NCBI EFetch Web API.
    /// If the EFetchQuery.Query Property is malformed a the Method will return an empty 
    /// List(NcbiSequence).
    /// Class instances can be saved to the Database and Seriealized or Deserialized.
    /// </summary>
    /// <seealso cref="GetESearchResults"/>
    [DataContract]
    public class EFetchQuery
    {
        #region Constructors
        public EFetchQuery() { }
        public EFetchQuery(NcbiEnums.Databases db, List<int> uidlist, 
            NcbiEnums.EFetchRetTypeMode retmode)
        {
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

            #region switch RetTypeMode
            switch (retmode)
            {
                case NcbiEnums.EFetchRetTypeMode.UidList:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.UidList;
                    break;

                case NcbiEnums.EFetchRetTypeMode.Alignment:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.Alignment;
                    break;

                case NcbiEnums.EFetchRetTypeMode.TinySeqFastA:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.TinySeqFastA;
                    break;

                case NcbiEnums.EFetchRetTypeMode.Native:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.Native;
                    break;

                case NcbiEnums.EFetchRetTypeMode.GBSeq:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.GBSeq;
                    break;

                case NcbiEnums.EFetchRetTypeMode.INSDSeq:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.INSDSeq;
                    break;

                case NcbiEnums.EFetchRetTypeMode.SNP:
                    RetTypeMode = NcbiContstants.EFetchRetTypeMode.SNP;
                    break;

                default:
                    throw new SequenceException(
                        string.Format("The input NcbiContstants.EFetchRetTypeMode did not match any known database type."));
            }
            #endregion


            UidList = uidlist;

            #region Build Query
            var sb = new StringBuilder();
            sb.Append(NcbiContstants.BaseUrls.EFetch);
            sb.Append(DB + "&id=");
            foreach (var id in uidlist)
            {
                sb.Append(id + ",");
            }

            sb.Remove(sb.Length - 1, 1);

            sb.Append(RetTypeMode);

            sb.Replace(" ", "+");

            Query = sb.ToString();
            #endregion

            QueryHash = SequenceMethods.GetISequenceHash(Query);
        }

        public EFetchQuery(NcbiSearchResult sr, 
            NcbiEnums.EFetchRetTypeMode retmode = NcbiEnums.EFetchRetTypeMode.TinySeqFastA)
            :this(sr.DB, sr.IdList, retmode){}

        public EFetchQuery(string qString)
        {
            Query = qString;
            QueryHash = SequenceMethods.GetISequenceHash(Query);
        }
        #endregion


        #region DataMembers
        [DataMember]
        public string Query { get; private set; }

        [Key]
        [DataMember]
        public string QueryHash { get; private set; }

        [DataMember]
        public string DB { get; private set; }

        [DataMember]
        public List<int> UidList { get; set; }

        [DataMember]
        public string RetTypeMode { get; private set; }

        #endregion
    }
}
