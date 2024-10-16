﻿using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Services;

namespace TreasureMap.Stategies;

/// <summary>
/// Strategy to move forward.
/// </summary>
public class MoveForwardStrategy : IMovementStrategy
{
    
    private readonly IMapService _mapService = MapService.Instance;

    public void Execute(Adventurer adventurer)
    {
        var newPosition = adventurer.Position;
        switch (adventurer.Orientation)
        {
            case Orientation.N:
                newPosition.Y -= 1;
                break;
            case Orientation.E:
                newPosition.X += 1;
                break;
            case Orientation.S:
                newPosition.Y += 1;
                break;
            case Orientation.W:
                newPosition.X -= 1;
                break;
        }

        if (_mapService.CanMoveAdventurer(adventurer, newPosition))
        {
            var cell = _mapService.GetCell(newPosition);
            adventurer.Position = newPosition;
            cell?.MoveTo(adventurer);
        }
    }
}