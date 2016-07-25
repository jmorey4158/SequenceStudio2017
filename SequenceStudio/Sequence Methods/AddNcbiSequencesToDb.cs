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
    public partial class SequenceMethods
    {
        public static async Task<int> AddNcbiSequencesToDb(List<NcbiSequence> slist)
        {
            var startCount = 0; var endCount = 0;

            using (var dbContext = new SequenceDBContext())
            {
                startCount = dbContext.NcbiSequences.Count();

                var existingHash = dbContext.NcbiSequences.Select(e => e.StrandHash).AsParallel().ToList();
                var newSequences = slist.AsParallel().Where(s => !existingHash.Contains(s.StrandHash)).ToList();

                //This isn't workign. Investigating...
                //newSequences.ForAll(n => dbContext.NcbiSequences.Add(n));
                foreach (var n in newSequences)
                {
                    dbContext.NcbiSequences.Add(n);
                }

                await dbContext.SaveChangesAsync();

                endCount = dbContext.NcbiSequences.Count();
            }
            return endCount - startCount;
        }
    }
}