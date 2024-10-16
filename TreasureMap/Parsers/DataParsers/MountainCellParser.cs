using TreasureMap.Attribute;
using TreasureMap.Models.Cells;
using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
/// Class responsible for parsing mountain cells.
/// </summary>
[Parsable(typeof(MountainCell))]
public class MountainCellParser : IDataParser
{
    private static MountainCellParser? _instance;

    private MountainCellParser()
    {
    }

    public static ISingleton GetInstance()
    {
        return _instance ??= new MountainCellParser();
    }

    /// <summary>
    /// Parse a line into a mountain cell and add to the map.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="mapService"></param>
    public void Parse(string[] line, IMapService mapService)
    {
        var x = int.Parse(line[1]);
        var y = int.Parse(line[2]);
        mapService.AddCell(new MountainCell(x, y));
    }
}