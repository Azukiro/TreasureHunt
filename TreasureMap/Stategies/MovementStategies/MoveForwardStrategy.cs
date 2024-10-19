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
    readonly Dictionary<Orientation, Position> _directionOffsets = new ()
    {
        { Orientation.N, new Position(0, -1) },
        { Orientation.E, new Position(1, 0) },
        { Orientation.S, new Position(0, 1) },
        { Orientation.W, new Position(-1, 0) }
    };
    
    public void Execute(Adventurer adventurer)
    {
        var newPosition = _directionOffsets[adventurer.Orientation] + adventurer.Position;

        var positionIsValid = mapService.CanMoveAdventurer(adventurer, newPosition);
        if (!positionIsValid) return;

        var cell = stateService.GetCell(newPosition);
        if (cell != null) adventurerEnterStrategyContext.ExecuteStrategy(adventurer, cell);

        adventurer.Position = newPosition;
    }
}