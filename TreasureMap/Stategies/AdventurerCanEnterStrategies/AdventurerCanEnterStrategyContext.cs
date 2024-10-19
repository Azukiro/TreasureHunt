using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Utils;

namespace TreasureMap.Stategies.AdventurerCanEnterStrategies;

/// <summary>
///     Interface for the adventurer can enter strategy.
/// </summary>
/// <param name="strategiesDictionary"></param>
public class AdventurerCanEnterStrategyContext(Dictionary<Type, IAdventurerCanEnterStrategy> strategiesDictionary)
{
    public bool ExecuteStrategy(Adventurer adventurer, Cell cell)
    {
        var cellType = cell.GetType();

        if (strategiesDictionary.TryGetValue(cellType, out var strategy)) return strategy.Execute(adventurer, cell);

        //Create a warning log to be sure that a strategy is not missing
        LoggerHelper.LogWarn($"No strategy found for cell type {cellType}");
        return true;
    }
}