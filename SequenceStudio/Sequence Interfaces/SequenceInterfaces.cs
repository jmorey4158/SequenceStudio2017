using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SequenceStudio
{
    public interface ISequence
    {
        string Strand { get; }
        string StrandHash { get; }
        SequenceEnums.SequenceType SequenceType { get; }
        SequenceEnums.SequenceOriginType SequenceOriginType { get; }
    }



    public interface ISequenceMetadata
    {
        Dictionary<string, int> ResidueStatistics { get; }
        decimal MolecularWeight { get; }
        int StrandLength { get; }
    }




    public interface IOpenReadingFrameMetadata
    {
        Dictionary<int, double> CodonStatistics { get; }
        Dictionary<int, string> CodonCount { get; }
    }

}
