using TreasureMap.Constants;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Services;

namespace TreasureMap.Parsers;

/// <summary>
/// Class responsible for parsing a treasure map.
/// </summary>
public class TreasureMapParser
{
    private readonly IMapService _mapService;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapService"></param>
    public TreasureMapParser(IMapService mapService)
    {
        _mapService = mapService;
    }
    
    private static readonly Dictionary<string, Type> TypeMappings = new(){
        { IoConstants.Mountain, typeof(MountainCell) },
        { IoConstants.Treasure, typeof(TreasureCell) },
        { IoConstants.Adventurer, typeof(Adventurer) },
        { IoConstants.BoundingBox, typeof(BoundingBox)}
    };
    
    /// <summary>
    /// Parse the lines into the map elements.
    /// </summary>
    /// <param name="lines"></param>
    public void Parse(string[] lines)
    {
        foreach (var line in lines)
        {
            var parts = line.Split(IoConstants.Separator);
            if (parts.Length == 0)
            {
                continue;
            }
            var type = parts[0];
            if (!TypeMappings.ContainsKey(type))
            {
                continue;
            }
            var parser = ParserFactory.GetParser(TypeMappings[type]);
            parser.Parse(parts, _mapService);
        }
        
        _mapService.ValidateMap();
    }
}