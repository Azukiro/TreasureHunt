using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Stategies.AdventurerCanEnterStrategies;

/// <summary>
///     Strategy to check if an adventurer can enter a mountain cell.
/// </summary>
public class MountainCellAdventurerCanEnterStrategy : IAdventurerCanEnterStrategy
{
    public bool Execute(Adventurer adventurer, Cell? cell)
    {
        return cell is not MountainCell;
    }
}