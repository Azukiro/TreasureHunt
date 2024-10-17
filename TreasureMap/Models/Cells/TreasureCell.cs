using System.ComponentModel.DataAnnotations;

namespace TreasureMap.Models.Cells;

/// <summary>
///     Class representing a treasure cell.
/// </summary>
public class TreasureCell : Cell
{
    /// <inheritdoc />
    public TreasureCell(int x, int y, int treasureCount) : base(x, y)
    {
        TreasureCount = treasureCount;
    }

    [Range(1, int.MaxValue, ErrorMessage = "Treasure count must be greater than 0.")]
    public int TreasureCount { get; private set; }

    public override void MoveTo(Adventurer adventurer)
    {
        if (TreasureCount > 0)
        {
            adventurer.TreasureCollected += 1;
            TreasureCount -= 1;
        }
    }
}