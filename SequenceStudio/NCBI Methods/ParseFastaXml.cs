using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {
        /// <summary>
        /// Parses through XDocument (from GetEFetchResults) and creates a List(FastARecord) class instances.
        /// </summary>
        /// <param name="xdoc">XDocument instance that represents a List(FastARecord).</param>
        /// <returns>List(FastARecord)</returns>
        /// <exception cref="SequenceException">SequenceException thrown if any of the XMLNode.Name = "ERROR".</exception>
        public static List<FastARecord> ParseFastaXml(XDocument xdoc)
        {
            #region Checks
            if (xdoc == null)
                throw new SequenceException("The input XML is Empty.");

            if(xdoc.Nodes().Count() == 0)
                throw new SequenceException("The input XML has no Nodes and does not represt a valid FastARecord.");

            if(xdoc.DescendantNodes().Count() == 0)
                throw new SequenceException("The input XML has no child Nodes and does not represt a valid FastARecord.");
            #endregion

            #region Method Body
            var fasta = new FastARecord();
            var fastaList = new List<FastARecord>();

            //Get all the TSeq Nodes.
            var TSeq = from t in xdoc.Descendants("TSeq")
                       select t;

            //Iterate through all the TSeq Nodes
            foreach (var tSeq in TSeq)
            {
                //Get all the TSeq Decendants. These contain the data we are after.
                var child = from desc in tSeq.Descendants()
                        select desc;

                //Iterate through the data nodes and populate the FastARecord instance.
                foreach (var c in child)
                {
                    #region switch
                    switch (c.Name.LocalName)
                        {
                            case "TSeq_seqtype":
                                fasta.SequenceType = c.Attribute("value").Value;
                                break;

                            case "TSeq_gi":
                                fasta.UniqueID = int.Parse(c.Value);
                                break;

                            case "TSeq_accver":
                                fasta.AccessionVersion = c.Value;
                                break;


                            case "TSeq_taxid":
                                fasta.TaxanomicID = int.Parse(c.Value);
                                break;

                            case "TSeq_orgname":
                                fasta.OrganismName = c.Value;
                                break;

                            case "TSeq_sid":
                                fasta.SeqID = c.Value;
                                break;

                            case "TSeq_defline":
                                fasta.Description = c.Value;
                                break;

                            case "TSeq_length":
                                fasta.SequenceLength = int.Parse(c.Value);
                                break;

                            case "TSeq_sequence":
                                fasta.Sequence = c.Value;
                                break;

                            default:
                                break;
                        }
                    #endregion
                }

                //Clean up nodes with null or empty.
                if (fasta.AccessionVersion == null)
                fasta.AccessionVersion = "not available";

                if (fasta.OrganismName == null)
                    fasta.OrganismName = "not available";

                if (fasta.SeqID == null)
                    fasta.SeqID = "not available";

                if (fasta.Description == null)
                    fasta.Description = "not available";

                if (fasta.Sequence == null)
                    fasta.Sequence = "not available";

                //Add the FastARecord to the List<FastARecord>
                fastaList.Add(fasta);

            }

            //List<FastARecord>
            return fastaList;

            #endregion
        }
    }
}
