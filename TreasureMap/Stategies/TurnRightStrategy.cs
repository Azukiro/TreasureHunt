using TreasureMap.Enums;
using TreasureMap.Models;

namespace TreasureMap.Stategies;

/// <summary>
/// Strategy to turn right.
/// </summary>
public class TurnRightStrategy : IMovementStrategy
{
    public void Execute(Adventurer adventurer)
    {
        adventurer.Orientation = adventurer.Orientation switch
        {
            Orientation.N => Orientation.E,
            Orientation.E => Orientation.S,
            Orientation.W => Orientation.N,
            Orientation.S => Orientation.W,
            _ => adventurer.Orientation
        };
    }
}