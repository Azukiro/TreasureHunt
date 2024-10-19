using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Services;
using TreasureMap.Stategies.AdventurerEnterStrategies;

namespace TreasureMap.Stategies.MovementStategies;

/// <summary>
///     Strategy to move forward
/// </summary>
/// <param name="mapService"></param>
/// <param name="stateService"></param>
/// <param name="adventurerEnterStrategyContext"></param>
public class MoveForwardStrategy(
    IMapService mapService,
    IStateService stateService,
    AdventurerEnterStrategyContext adventurerEnterStrategyContext) : IMovementStrategy
{
    public void Execute(Adventurer adventurer)
    {
        var newPosition = new Position(adventurer.Position.X, adventurer.Position.Y);
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

        var positionIsValid = mapService.CanMoveAdventurer(adventurer, newPosition);
        if (!positionIsValid) return;

        var cell = stateService.GetCell(newPosition);
        if (cell != null) adventurerEnterStrategyContext.ExecuteStrategy(adventurer, cell);

        adventurer.Position = newPosition;
    }
}