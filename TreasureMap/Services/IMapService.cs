﻿using TreasureMap.Models;

namespace TreasureMap.Services;

/// <summary>
///     Service for the management of the map.
/// </summary>
public interface IMapService
{
    /// <summary>
    ///     Check if the map is valid.
    /// </summary>
    void ValidateMap();

    /// <summary>
    ///     Check if an adventurer can move to a position.
    /// </summary>
    /// <param name="adventurer"></param>
    /// <param name="potentialPosition"> Potential position to move to. </param>
    /// <returns></returns>
    bool CanMoveAdventurer(Adventurer adventurer, Position potentialPosition);

    /// <summary>
    ///     Check if a position is inside the map.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    bool IsInsideMap(Position position);
}