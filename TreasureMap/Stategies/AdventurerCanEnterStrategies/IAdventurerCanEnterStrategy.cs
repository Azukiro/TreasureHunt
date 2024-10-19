using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Stategies.AdventurerCanEnterStrategies;

/// <summary>
///     Interface for the adventurer can enter strategy.
/// </summary>
public interface IAdventurerCanEnterStrategy
{
    public bool Execute(Adventurer adventurer, Cell? cell);
}