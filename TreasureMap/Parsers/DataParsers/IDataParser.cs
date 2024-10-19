using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Interface for data parsers.
/// </summary>
public interface IDataParser
{
    /// <summary>
    ///     Parses a line of data.
    /// </summary>
    /// <param name="lineData"></param>
    /// <param name="stateService"></param>
    void Parse(string[] lineData, IStateService stateService);
}