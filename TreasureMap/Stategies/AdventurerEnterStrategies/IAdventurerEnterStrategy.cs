using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Stategies.AdventurerEnterStrategies;

/// <summary>
///     Interface for the adventurer enter strategy.
/// </summary>
public interface IAdventurerEnterStrategy
{
    void Execute(Adventurer adventurer, Cell cell);
}