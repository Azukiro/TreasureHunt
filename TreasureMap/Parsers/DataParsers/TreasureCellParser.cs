using TreasureMap.Attribute;
using TreasureMap.Models.Cells;
using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
/// Class responsible for parsing treasure cells. 
/// </summary>
[Parsable(typeof(TreasureCell))]
public class TreasureCellParser : IDataParser
{
    private static TreasureCellParser? _instance;

    private TreasureCellParser()
    {
    }

    public static ISingleton GetInstance()
    {
        return _instance ??= new TreasureCellParser();
    }
    
    /// <summary>
    /// Parse a line into a treasur cell and add to the map.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="mapService"></param>
    public void Parse(string[] line, IMapService mapService)
    {
        var x = int.Parse(line[1]);
        var y = int.Parse(line[2]);
        var treasureCount = int.Parse(line[3]);
        mapService.AddCell(new TreasureCell(x, y, treasureCount));
    }
}