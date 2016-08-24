using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public partial class SequenceDBContext : DbContext
    {
        //public DbSet<DNA> ManualDNAs { get; set; }
        //public DbSet<DNA> SequencingDNAs { get; set; }
        public DbSet<NcbiSequence> NcbiSequences { get; set; }

        public DbSet<EFetchQuery> EFetchQueries { get; set;}


        //public DbSet<RNA> ORFs { get; set; }
        //public DbSet<RNA> RNAs { get; set; }

        //public DbSet<Polypeptide> Polypeptides { get; set; }
        //public DbSet<Polypeptide> TranslationProducts { get; set; }

        //public DbSet<ConsensusDNA> ConsensusDNAs { get; set; }


    }
}