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
    /// <param name="line"></param>
    /// <param name="stateService"></param>
    void Parse(string[] line, IStateService stateService);
}