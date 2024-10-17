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
    private readonly IStateService _stateService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapService"></param>
    /// <param name="stateService"></param>
    public TreasureMapParser(IMapService mapService, IStateService stateService)
    {
        _mapService = mapService;
        _stateService = stateService;
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
            if (!TypeMappings.TryGetValue(type, out var mapping))
            {
                continue;
            }
            var parser = ParserFactory.GetParser(mapping);
            parser.Parse(parts, _stateService);
        }
        
        _mapService.ValidateMap();
    }
}