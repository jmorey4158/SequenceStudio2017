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
        /// <summary>
        /// Internal Method AddNcbiSequencesToDb - This method takes a List(NcbiSequence), checks to make sure the sequence is not already
        ///     in the DB (by comparing hashes) and then uploads them to the DB.
        /// </summary>
        /// <param name="slist">List(NcbiSequence) - the list of NcbiSequence class instances to be added to the DB</param>
        /// <returns>Task(int) that indicates the number of sequences that could not be added to the DB.</returns>
        /// <remarks>If a sequence is already in the DB then the method moves to the next sequence. 
        /// The consumer can compare the number of sequences passed to the number added to determine how 
        ///     many sequences were already int the DB.  This method does not throw any exceptions, unless the await times out.</remarks>
        public static async Task<int> AddNcbiSequencesToDb(List<NcbiSequence> slist)
        {
            var startCount = 0; var endCount = 0;

            using (var dbContext = new SequenceDBContext())
            {
                startCount = dbContext.NcbiSequences.Count();

                // Grab the existing sequence hashes from the DB to compare with the incoming hashes
                var existingHash = dbContext.NcbiSequences.Select( e => e.StrandHash ).AsParallel().ToList();

                // Make a new List(NcbiSequences) of only the sequences not already in the DB -- The DB cannot contain duplicate hashes
                var newSequences = slist.AsParallel().Where( s => !existingHash.Contains(s.StrandHash) ).ToList();

                foreach (var n in newSequences)
                {
                    dbContext.NcbiSequences.Add(n);
                }

                await dbContext.SaveChangesAsync();

                endCount = dbContext.NcbiSequences.Count();
            }

            // Return the number of failed adds
            return endCount - startCount;
        }
    }
}