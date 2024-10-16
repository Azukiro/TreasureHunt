using System.ComponentModel.DataAnnotations;
using TreasureMap.Attribute;
using TreasureMap.Exceptions;
using TreasureMap.Parsers;

namespace TreasureMap.Models.Cells;

/// <summary>
/// Class representing a treasure cell.
/// </summary>
public class TreasureCell : Cell
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Treasure count must be greater than 0.")]
    public int TreasureCount { get; set; }
    

    /// <inheritdoc />
    public TreasureCell(int x, int y, int treasureCount) : base(x, y)
    {
        TreasureCount = treasureCount;
    }

    public override void MoveTo(Adventurer adventurer)
    {
        if (TreasureCount > 0)
        {
            adventurer.TreasureCount += 1;
            TreasureCount -= 1;
        }
    }
}