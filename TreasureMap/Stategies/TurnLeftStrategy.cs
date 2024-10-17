using TreasureMap.Enums;
using TreasureMap.Models;

namespace TreasureMap.Stategies;

/// <summary>
///     Strategy to turn left.
/// </summary>
public class TurnLeftStrategy : IMovementStrategy
{
    public void Execute(Adventurer adventurer)
    {
        adventurer.Orientation = adventurer.Orientation switch
        {
            Orientation.N => Orientation.W,
            Orientation.E => Orientation.N,
            Orientation.W => Orientation.S,
            Orientation.S => Orientation.E,
            _ => adventurer.Orientation
        };
    }
}