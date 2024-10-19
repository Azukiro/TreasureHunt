using TreasureMap.Attribute;
using TreasureMap.Models.Cells;
using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Class responsible for parsing treasure cells.
/// </summary>
[Parsable(typeof(TreasureCell))]
public class TreasureCellParser : IDataParser
{
    /// <summary>
    ///     Parse a line into a treasur cell and add to the map.
    /// </summary>
    /// <param name="lineData"></param>
    /// <param name="stateService"></param>
    public void Parse(string[] lineData, IStateService stateService)
    {
        var x = int.Parse(lineData[1]);
        var y = int.Parse(lineData[2]);
        var treasureCount = int.Parse(lineData[3]);
        stateService.AddCell(new TreasureCell(x, y, treasureCount));
    }
}