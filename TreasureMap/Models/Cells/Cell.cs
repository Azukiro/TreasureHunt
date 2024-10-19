using TreasureMap.Validators.Attribute;

namespace TreasureMap.Models.Cells;

/// <summary>
///     Base class for a cell in the map.
/// </summary>
public abstract class Cell
{
    /// <summary>
    ///     Constructor of the cell.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    protected Cell(int x, int y)
    {
        Position = new Position(x, y);
    }

    /// <summary>
    ///     Position of the cell in the map.
    /// </summary>
    [PositionInMap]
    [UniquePositionInMap]
    public Position Position { get; }
}