using TreasureMap.Attribute;
using TreasureMap.Models.Cells;
using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Class responsible for parsing mountain cells.
/// </summary>
[Parsable(typeof(MountainCell))]
public class MountainCellParser : IDataParser
{
    /// <summary>
    ///     Parse a line into a mountain cell and add to the map.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="stateService"></param>
    public void Parse(string[] line, IStateService stateService)
    {
        var x = int.Parse(line[1]);
        var y = int.Parse(line[2]);
        stateService.AddCell(new MountainCell(x, y));
    }
}