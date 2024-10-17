using TreasureMap.Attribute;
using TreasureMap.Models;
using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
/// Class responsible for parsing the BoudingMap.
/// </summary>
[Parsable(typeof(BoundingBox))]
public class BoundingMapParser : IDataParser
{
    /// <summary>
    /// Parsing a line into a bounding map and add to the map. 
    /// </summary>
    /// <param name="line"></param>
    /// <param name="stateService"></param>
    public void Parse(string[] line, IStateService stateService)
    {
        var width = int.Parse(line[1]);
        var height = int.Parse(line[2]);
        stateService.SetBoundingBox(new BoundingBox(width,height));
    }
}