using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {
        /// <summary>
        /// Takes FastARecord instance and retuens a NcbiSequence instance. 
        /// The NcbiSequence instance is the one stored in the Database.
        /// </summary>
        /// <param name="fasta">FastARecord instance</param>
        /// <returns>NcbiSequence instance</returns>
        /// <exception cref="SequenceException"/>
        public static NcbiSequence FastaToNcbiSequence (FastARecord fasta)
        {
            #region Checks
            //This will probably never be thrown becasue the FastARecord ctor 
            //is only called by Golden Path. But better safe than sorry.
            if (string.IsNullOrEmpty(fasta.Sequence))
                throw new SequenceException(string.Format("The specified FastARecord.Sequence is Empty or Null."));
            #endregion


            var s = fasta.Sequence;
            fasta.SequenceType = "";
            //Matches input sequence with RegexPattern for that sequence type
            if(!Regex.IsMatch(s,RegexePatterns.neg_regexDNA))
                return new NcbiSequence(fasta,SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.NCBI);

            if(!Regex.IsMatch(s,RegexePatterns.neg_regexRNA))
                return new NcbiSequence(fasta, SequenceEnums.SequenceType.RNA, SequenceEnums.SequenceOriginType.NCBI);

            if (!Regex.IsMatch(s,RegexePatterns.neg_regexAAshort))
                return new NcbiSequence(fasta, SequenceEnums.SequenceType.Polypeptide, SequenceEnums.SequenceOriginType.NCBI);

            //This will probably never be thrown becasue the FastARecord ctor calls Validate(SequenceType). But better safe than sorry.
            throw new SequenceException(string.Format("The specified FastARecord.SequenceType {0} does not match any known formats."
                ,fasta.SequenceType ));

        }
    }
}