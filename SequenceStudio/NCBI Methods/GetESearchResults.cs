using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {
        /// <summary>
        /// Asynchronous Method that calls NCMI ESearch Web API using the specified ESearchQuery class instance.
        /// This Method should return very quickly because the ESezrch only returns a list of 
        /// UniqueIDs of the sequences that match the given query.
        /// If the search Term dows not match any entries in the Entrez DB, Method
        /// returns an empty NcbiSearchResult class instance.
        /// The NcbiSearchResult class instance contains the relevant information from the API query.
        /// </summary>
        /// <param name="query"> An ESearchQuery class instance. The Query Property is used to make the call.</param>
        /// <returns>Task(NcbiSearchResult).</returns>
        /// <seealso cref="NcbiSearchResult"/>
        /// <seealso cref="ESearchQuery"/>
        public static async Task<NcbiSearchResult> GetESearchResults(ESearchQuery query)
        {
            var responseText = "";

            //Get string representing the ESearch Results
            WebRequest request = WebRequest.Create(query.Query);
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                {
                    responseText =  await responseStream.ReadToEndAsync();
                }
            }

            //Pasre the string to deserialize and create NcbiSearchResult
            var results = ParseSearchResult(responseText);

            //The DB Enum dowsn't need to be resolved here.
            //It will be resolved in the GetEFetchResults() method.
            results.DB = query.DbEnum;

            //Task<NcbiSearchResult>
            return results;
        }

    }
}
