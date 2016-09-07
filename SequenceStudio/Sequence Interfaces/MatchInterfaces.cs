using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SequenceStudio
{
    /// <summary>
    /// Interface IMatch - The definition of all Match classes to follow. The IMatch contract ensures that
    ///     all the proper data and metadata is encapsulated for use and storage. 
    ///     A Match can be computationally-expensive and so the IMatch contains a hash of the relevant metadata
    ///     to ensure that the hash uniquely identifies this Match. The has is then stored as the ID of 
    ///     the serialized Match instance in the Data Source.
    /// </summary>
    /// <remarks>A Match instance can be large and computationally-expensive. 
    /// That is why they are always stored in the Repository and their MatchID is passed rather than the actual instance.</remarks>
    public interface IMatch
    {
        string ID { get; }
        SequenceEnums.SequenceType SequenceType { get; }
        SequenceEnums.SequenceOriginType TemplateType { get; }
        SequenceEnums.SequenceOriginType PatternType { get; }
        SequenceEnums.MatchType MatchType { get; }
        string MatchID { get; }
        string TemplateID { get; }
        string PatternID { get; }
        int Threshold { get; }
        Dictionary<int, int> Matches { get; }
    }

    /// <summary>
    /// Interface IMatchSet - The definition of all MatchSet classes to follow. 
    ///     A MAtchSet is a user-defined set of Match instance for a user-defined purpose.
    ///     The Match instances are referred to by their MatchID (hash).
    /// </summary>
    /// <remarks>IMatchSet is a light-weight object that references Match objects that
    ///     are already in the Repository.</remarks>
    public interface IMatchSet
    {
        string Name { get; }
        Guid ID { get; }
        List<string> MatchIDs { get; }
    }
}
