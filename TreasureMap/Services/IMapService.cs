using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Services;

/// <summary>
/// Service for the management of the map.
/// </summary>
public interface IMapService
{
    /// <summary>
    /// Validate the map.
    /// </summary>
    void ValidateMap();
    
    /// <summary>
    /// Check if an adventurer can move to a position.
    /// </summary>
    /// <param name="adventurer"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    bool CanMoveAdventurer(Adventurer adventurer, Position potentialPosition);
    
    /// <summary>
    ///  Check if a position is inside the map.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    bool IsInsideMap(Position position);
}