using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {
        /// <summary>
        /// Asynchronous Method that calls NCMI EFetch Web API using the specified EFetchQuery class instances.
        /// This Method might take a long time to return if many sequence IDs are included in the
        /// List(NcbiSequence) because the EFetch returns a list of 
        /// NcbiSequences and the Sequences can be very long.
        /// The NcbiSequence class instance contains the relevant information from the API query, 
        /// including the actual DNA, RNA, or Protein sequence.</summary>
        /// <param name="query">An EFetchQuery class instance. 
        /// The EFetchQuery.Query (string) is used by this Method to call the NCBI EFetch Web API.</param>
        /// <returns>List(NcbiSequence)</returns>
        public static async Task<List<NcbiSequence>> GetEFetchResults(EFetchQuery query)
        {
            #region Checks
            if (string.IsNullOrEmpty(query.Query))
                throw new SequenceException(
                     string.Format("The provided EFetchQuery.Query {0} is null or Empty. The EFetch call will not be made.", query.Query));

            if(string.IsNullOrWhiteSpace(query.Query))
                throw new SequenceException(
                     string.Format("The provided EFetchQuery.Query {0} Null or WhiteSpace characters only. The EFetch call will not be made.", query.Query));
            
            if(query.UidList.Count == 0)
                 throw new SequenceException(
                     string.Format("The provided EFetchQuery.UidList was empty. The EFetch call will not be made."));

            #endregion


            var pub = new EventPublisher();
            var start = new SequenceEventArgs("EFetch call strated.", "EFetchQuery", "GetEFetchResults");
            pub.OnNcbiFetchStarted(start);

            var responseText = "";
            var ncbiSequenceList = new List<NcbiSequence>();

            //Get string representing the ESearch Results
            //This call can take a long time depending upon the number of
            //Sequences to be returned, the length of the sequences, and network conditions.
            WebRequest request = WebRequest.Create(query.Query);
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                {
                    responseText = await responseStream.ReadToEndAsync();
                }
            }

            //Generate XDocument from returned string
            if (string.IsNullOrEmpty(responseText))
                throw new SequenceException(
                    string.Format("The provided EFetchQuery.Query {0} did not natch any entries in the Entrez Database."
                    , query.Query));

            //Create XDocument from responseText which is the string returned from NCBI EFetch Web API
            var xdoc = XDocument.Parse(responseText);

            //Pasre the XDocument to deserialize and create List<FastARecord>
            var fastaList = ParseFastaXml(xdoc);

            //Interates through the List<FastARecord> and calls FastaToNcbiSequence(f)
            //foreach FastARecord to convert it to a NcbiSequence
            foreach (var f in fastaList)
            {
                ncbiSequenceList.Add(FastaToNcbiSequence(f));
            }

            var completed = new SequenceEventArgs("EFetch call completed.", "EFetchQuery", "GetEFetchResults");
            pub.OnNcbiFetchStarted(completed);

            //Task < List<NcbiSequence> >
            return ncbiSequenceList;
        }


        /// <summary>
        /// IMPORTANT: Use for tesing purposes ONLY. 
        /// 
        /// Overload Asynchronous Method that calls NCBI EFetch Web API using the specified string.
        /// NOTE: THe input string must represent a valid EFetch query.
        /// Method creates an EFetchQuery class instance from the input string and
        /// then calls the other GetEFetchResults() Method.
        /// This Method might take a long time to return if many sequence IDs are included in the
        /// List(NcbiSequence) because the EFetch returns a list of 
        /// NcbiSequences and the Sequences can be very long.</summary>
        /// <param name="query">A string that must be a valid EFetch query.</param>
        /// <returns>List(NcbiSequence)</returns>
        private static async Task<List<NcbiSequence>> GetEFetchResults(string queryString)
        {
            var ret = GetEFetchResults(new EFetchQuery(queryString));
            return await ret;
        }

    }
}
