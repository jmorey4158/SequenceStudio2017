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
        public static async Task<int> NcbiEndToEnd(NcbiEnums.Databases db, string term,
            NcbiEnums.Fields field = NcbiEnums.Fields.EMPTY,
            NcbiEnums.RetMode retmode = NcbiEnums.RetMode.Xml,
            NcbiEnums.ESearchRetType rettype = NcbiEnums.ESearchRetType.eUtility,
            int retmax = 20,
            int retstart = 0)
        {
            var sq = new ESearchQuery(db, term);

            var sr = GetESearchResults(sq).Result;

            var fq = new EFetchQuery(sr);

            var qList = new List<EFetchQuery>();
            qList.Add(fq);
            var qcount = AddEFetchQueryToDb(qList).Result;

            var fr = GetEFetchResults(fq).Result;


            return await SequenceMethods.AddNcbiSequencesToDb(fr);
        }

    }


}