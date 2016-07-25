using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {
        public delegate IFastaRecord GetNcbiMatchedDelegate(ISequence pattern, SequenceEnums.SequenceType st, int threshold);

        public static IFastaRecord FindNcbiMatches(ISequence pattern, SequenceEnums.SequenceType st,int threshold, SequenceEnums.NcbiMatchType mt)
        {
            if (string.IsNullOrEmpty(pattern.Strand))
                throw new SequenceException(string.Format("The specified 'strand' is empty or null."));

            if (threshold > 100)
                threshold = 100;
            if (threshold < 1)
                threshold = 1;

            switch (pattern.SequenceType)
            {
                case (SequenceEnums.SequenceType.DNA):
                    break;

                case (SequenceEnums.SequenceType.RNA):
                    break;

                case (SequenceEnums.SequenceType.Polypeptide):
                    break;



                default:
                    break;
            }


            FastARecord rec = new FastARecord();

            string ncbi = "";
            ISequence NcbiTemplate = null;

            switch (pattern.SequenceType)
            {
                case (SequenceEnums.SequenceType.DNA):
                    NcbiTemplate = new DNA(ncbi, SequenceEnums.SequenceOriginType.NCBI);
                    break;

                case (SequenceEnums.SequenceType.RNA):
                    NcbiTemplate = new RNA(ncbi, SequenceEnums.SequenceOriginType.NCBI);
                    break;

                case (SequenceEnums.SequenceType.Polypeptide):
                    NcbiTemplate = new Polypeptide(ncbi, SequenceEnums.SequenceOriginType.NCBI);
                    break;
            }



            var matches = new Dictionary<int, int>();

            return new FastARecord();
        }
    }
}
