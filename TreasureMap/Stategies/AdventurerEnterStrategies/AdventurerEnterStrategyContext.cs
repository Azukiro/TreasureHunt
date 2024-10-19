using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Utils;

namespace TreasureMap.Stategies.AdventurerEnterStrategies;

/// <summary>
///     Context for the adventurer enter strategies.
/// </summary>
/// <param name="strategiesDictionary"></param>
public class AdventurerEnterStrategyContext(Dictionary<Type, IAdventurerEnterStrategy> strategiesDictionary)
{
    public void ExecuteStrategy(Adventurer adventurer, Cell cell)
    {
        var cellType = cell.GetType();

        if (strategiesDictionary.TryGetValue(cellType, out var strategy))
            strategy.Execute(adventurer, cell);
        else
            //Create a warning log to be sure that a strategy is not missing
            LoggerHelper.LogWarn($"No strategy found for cell type {cellType}");
    }
}