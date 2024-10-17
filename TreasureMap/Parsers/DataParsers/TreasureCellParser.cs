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
    /// <param name="line"></param>
    /// <param name="stateService"></param>
    public void Parse(string[] line, IStateService stateService)
    {
        var x = int.Parse(line[1]);
        var y = int.Parse(line[2]);
        var treasureCount = int.Parse(line[3]);
        stateService.AddCell(new TreasureCell(x, y, treasureCount));
    }
}