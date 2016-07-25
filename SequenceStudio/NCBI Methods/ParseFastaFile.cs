using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {
        public static FastARecord ParseFastaFile(string file, string extention)
        {
            if (string.IsNullOrWhiteSpace(file))
                throw new SequenceException("The input File is not a valid FastA File.");


            var br = "\n";

            var f = file.IndexOf(br);
            var header = file.Substring(0, f);
            var sequence = Regex.Replace(file.Substring(f, file.Length - f), br, "");
            var fasta = new FastARecord();

            try
            {
                var pipes = Regex.Matches(header, @"\|");

                var db = header.Substring(1, pipes[0].Index - 1);
                var uID = header.Substring(pipes[0].Index + 1, ( pipes[1].Index - pipes[0].Index) - 1);
                var type = header.Substring(pipes[1].Index + 1, (pipes[2].Index - pipes[1].Index) - 1);
                var asec = header.Substring(pipes[2].Index + 1, (pipes[3].Index - pipes[2].Index) - 1);
                var desc = header.Substring(pipes[3].Index + 1, header.Length - (pipes[3].Index + 1));

                fasta.UniqueID = int.Parse(uID);
                fasta.AccessionVersion = asec;
                fasta.Sequence = sequence;
                fasta.SequenceLength = sequence.Length;
                fasta.Description = desc;

                switch (extention)
                {
                    case ".aa":
                        fasta.SequenceType = SequenceTypes.Poypeptide;
                        break;

                    case ".nt":
                        fasta.SequenceType = SequenceTypes.DNA;
                        break;

                    default:
                        break;
                }

            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (RegexMatchTimeoutException)
            {
                throw;
            }
            catch (IndexOutOfRangeException)
            {

                throw;
            }
            catch (Exception)
            {
                throw;
            }


            
             

            




            return fasta;
        }
    }
}
