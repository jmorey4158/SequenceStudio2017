using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    public static partial class SequenceMethods
    {

        public static string GetComplimentStrand(DNA d)
        {
            var sb = new StringBuilder();
            string seq = d.Strand;

            for (int index = 0; index <= seq.Length - 1; index++)
            {
                switch (seq.Substring(index, 1))
                {
                    case "A":
                        sb.Append("T");
                        break;
                    case "C":
                        sb.Append("G");
                        break;
                    case "T":
                        sb.Append("A");
                        break;
                    case "G":
                        sb.Append("C");
                        break;
                    case "N":
                        sb.Append("N");
                        break;
                    default:
                        break;
                }
            }
            return sb.ToString();
        }


        public static string GetReverseStrand(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            string seq = d.Strand;

            for (int index = seq.Length - 1; index >= 0; index--)
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }


        public static string GetReverseComplimentStrand(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            string seq = GetComplimentStrand(d);

            for (int index = seq.Length - 1; index >= 0; index--)
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }

    }


}
