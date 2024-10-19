using System.ComponentModel.DataAnnotations;

namespace TreasureMap.Models.Cells;

/// <summary>
///     Class representing a treasure cell.
/// </summary>
public class TreasureCell : Cell
{
    /// <inheritdoc />
    /// <param name="treasureCount"> Number of treasures in the cell. </param>
    /// <remarks> The number of treasures must be greater than 0. </remarks>
    public TreasureCell(int x, int y, int treasureCount) : base(x, y)
    {
        TreasureCount = treasureCount;
    }

    /// <summary>
    ///     Number of treasures in the cell.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Treasure count must be greater than 0.")]
    public int TreasureCount { get; set; }
}