using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{

    /// <summary>
    /// 
    /// </summary>
    public static class SequenceEnums
    {

        public enum AminoAcids
        {
            Alanine, Cysteine, AsparticAcid, GlutamicAcid,
            Phenylalanine, Glycine, Histidine, Isoleucine,
            Lysine, Leucine, Methionine, Asparagine, Proline,
            Glutamine, Arginine, Serine, Threonine,
            Valine, Tryptophan, Tyrosine
        }


        public enum SequenceType
        {
            DNA, RNA, Polypeptide, ConsensusDNA
        }


        public enum SequenceOriginType
        {
            Random, Manual, Sequencing, NCBI, SourceStrand,
            ConsensusStrand, ComplimentStrand, ReverseComplimentStrand, TranslationProduct, 
            TranscriptionProduct, Substrand, ORF
        }


        public enum MatchType
        {
            ExactMatch, PercentageMatch, ContiguousMatch, Empty
        }


        public enum NcbiMatchType
        {
            Blast, FastA, DNA, RNA, Polypeptide
        }


    }
}

