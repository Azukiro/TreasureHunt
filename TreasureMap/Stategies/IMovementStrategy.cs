using TreasureMap.Models;

namespace TreasureMap.Stategies;

/// <summary>
///     Interface for the movement strategy.
/// </summary>
public interface IMovementStrategy
{
    /// <summary>
    ///     Execute the strategy.
    /// </summary>
    /// <param name="adventurer"></param>
    void Execute(Adventurer adventurer);
}