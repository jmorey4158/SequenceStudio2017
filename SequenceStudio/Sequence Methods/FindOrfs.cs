using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public static partial class SequenceMethods
    {

        public static List<Orf> FindOrfs(DNA d)
        {
            string seq = d.Strand;
            // TODO: Add implementation FindOrfs(DNA d)
            return new List<Orf>();
        }

        public static List<Orf> FindOrfs(RNA r)
        {
            string seq = r.Strand;
            // TODO: Add implementation FindOrfs(RNA r)
            return new List<Orf>();
        }
    }
}
