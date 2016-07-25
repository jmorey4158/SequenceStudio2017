using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public static class SequenceTypes
    {
        public const string DNA = "DNA";
        public const string RNA = "RNA";
        public const string Poypeptide = "Poypeptide";
        public const string ConsensusDNA = "ConsensusDNA";
    }


    public static class SequenceOriginTypes
    {
        public const string Random = "Random";
        public const string Manual = "Manual";
        public const string Sequencing = "Sequencing";
        public const string NBCI = "NBCI";
        public const string SourceStrand = "SourceStrand";
        public const string ConsensusStrand = "ConsensusStrand";
        public const string ComplimentStrand = "ComplimentStrand";
        public const string ReverseComplimentStrand = "ReverseComplimentStrand";
        public const string TranscriptionProduct = "TranscriptionProduct";
        public const string Substrand = "Substrand";
    }


    public static class MatchTypes
    {
        public const string ExactMatch = "ExactMatch";
        public const string PercentageMatch = "PercentageMatch";
        public const string ContiguousMatch = "ContiguousMatch";
        public const string Empty = "Empty";
    }
}
