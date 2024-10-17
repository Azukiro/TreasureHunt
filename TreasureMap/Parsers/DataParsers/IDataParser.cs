using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///  Interface for data parsers.
/// </summary>
public interface IDataParser
{
    /// <summary>
    ///  Parses a line of data.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="mapService"></param>
    void Parse(string[] line, IMapService mapService);
}