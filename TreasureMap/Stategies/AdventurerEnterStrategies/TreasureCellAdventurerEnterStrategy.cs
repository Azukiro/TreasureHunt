using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Stategies.AdventurerEnterStrategies;

/// <summary>
///     Strategy for the adventurer to enter a treasure cell.
/// </summary>
public class TreasureCellAdventurerEnterStrategy : IAdventurerEnterStrategy
{
    public void Execute(Adventurer adventurer, Cell cell)
    {
        if (cell is TreasureCell treasureCell)
        {
            treasureCell.TreasureCount--;
            adventurer.TreasureCollected++;
        }
        else
        {
            throw new InvalidOperationException("Invalid cell type for this strategy");
        }
    }
}