using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Utils;

namespace TreasureMap.Stategies.MovementStategies;

/// <summary>
///     Context for the movement strategies.
/// </summary>
/// <param name="strategiesDictionary"></param>
public class MovementStrategyContext(Dictionary<Movement, IMovementStrategy> strategiesDictionary)
{
    public void ExecuteStrategy(Movement movement, Adventurer adventurer)
    {
        if (strategiesDictionary.TryGetValue(movement, out var strategy))
            strategy.Execute(adventurer);
        else
            //Create a warning log to be sure that a strategy is not missing
            LoggerHelper.LogWarn($"No strategy found for movement {movement}");
    }
}