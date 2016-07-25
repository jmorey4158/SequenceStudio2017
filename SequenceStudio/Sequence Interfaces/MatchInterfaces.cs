using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SequenceStudio
{
    public interface IMatch
    {
        string ID { get; }
        SequenceEnums.SequenceType SequenceType { get; }
        SequenceEnums.SequenceOriginType TemplateType { get; }
        SequenceEnums.SequenceOriginType PatternType { get; }
        SequenceEnums.MatchType MatchType { get; }
        string TemplateID { get; }
        string PatternID { get; }
        int Threshold { get; }
        Dictionary<int, int> Matches { get; }

    }


    public interface IMatchSet
    {
        string Name { get; }
        Guid ID { get; }
        List<IMatch> List { get; }
    }
}
