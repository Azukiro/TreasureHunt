using TreasureMap.Models;
using TreasureMap.Models.Cells;

namespace TreasureMap.Stategies.AdventurerCanEnterStrategies;

/// <summary>
///     Interface for the adventurer can enter strategy.
/// </summary>
public interface IAdventurerCanEnterStrategy
{
    /// <summary>
    ///     Execute the strategy.
    /// </summary>
    /// <param name="adventurer"></param>
    /// <param name="cell"></param>
    /// <returns> return true if the adventurer can enter the cell, false otherwise</returns>
    public bool Execute(Adventurer adventurer, Cell? cell);
}