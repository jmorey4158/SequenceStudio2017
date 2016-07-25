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
        /// Synchronous -- Parses the resulting string from a call to the NCBI ESearch Web API
        /// and creates a NcbiSearchResult calss instance. 
        /// </summary>
        /// <param name="result">The string passed to this from GetESearchResults.
        /// The sring represents the results from the eSearch call to NCBI.</param>
        /// <returns>NcbiSearchResult</returns>
        /// <remarks>Called by GetESearchResults. Result passed back to GetESearchResults.</remarks>
        /// <seealso cref="GetESearchResults"/>
        /// <exception cref="Exception"/>
        public static NcbiSearchResult ParseSearchResult(string result)
        {

            var searchResult = new NcbiSearchResult();

            //This is risky enough to justify a try block. 
            //The most probable cause for concern is a bad ESearch Query resilting in 
            //an empty NcbiSearchResult.
            try
            {
                //Create XDocument from string (from 
               var xdoc = XDocument.Parse(result);

               if (xdoc == null)
                throw new SequenceException("The input string is not a valid NcbiSearchResult.");

               if (xdoc.Nodes().Count() == 0)
                throw new SequenceException("The input string is not a valid NcbiSearchResult.");


                DataContractSerializer dcs = new DataContractSerializer(typeof(NcbiSearchResult));
                var list = new List<int>();

                //Generates the NcbiSearchResult without the IdList
                using (var xr = xdoc.CreateReader())
                {
                    while (xr.Read())
                    {
                        if ((xr.NodeType == XmlNodeType.Element) && (xr.Name == "eSearchResult"))
                            searchResult = (NcbiSearchResult)dcs.ReadObject(xr);
                    }
                }

                //Generates the IdList. I don't like having to do this, but still looking for better path
                using (var xl = xdoc.CreateReader())
                {
                    xl.ReadToFollowing("IdList");
                    xl.ReadToDescendant("Id");

                    for (int i = 0; i < searchResult.RetMax; i++)
                    {
                        list.Add(int.Parse(xl.ReadInnerXml()));
                    }
                }

                //stuff the list of Ids into the NcbiSearchResult
                searchResult.IdList = list;
            }
            catch (Exception)
            {
                throw;
            }

            return searchResult;
        }

    }
}