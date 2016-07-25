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
        /// 
        /// </summary>
        /// <param name="qslist"></param>
        /// <returns></returns>
        public static async Task<int> AddEFetchQueryToDb(List<EFetchQuery> qslist)
        {
            var startCount = 0; var endCount = 0;

            using (var dbContext = new SequenceDBContext())
            {
                startCount = dbContext.EFetchQueries.Count();

                //Create a list of existing EFetchQuery.QueryHashes. 
                //Then create a list of the new EFetchQuery instances
                //that are not already in the Database.
                //Use .AsParallel() to make it really fast. Yeah!
                var existingHash = dbContext.EFetchQueries.Select(n => n.QueryHash).ToList().AsParallel();
                var newQueries = qslist.AsParallel().Where(s => !existingHash.Contains(s.QueryHash)).ToList();

                //This isn't working. Investigating....
                //newQueries.ForAll(n => dbContext.EFetchQueries.Add(n));

                //Using this syntax because the .ForAll() method isn't working....
                foreach (var n in newQueries)
                {
                    dbContext.EFetchQueries.Add(n);
                }

                await dbContext.SaveChangesAsync();

                endCount = dbContext.EFetchQueries.Count();
            }

            //Calculate the number of EFetchQuery instances added to the Database.
            return endCount - startCount;
        }


    }


}