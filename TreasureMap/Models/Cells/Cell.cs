using TreasureMap.Validators.Attribute;

namespace TreasureMap.Models.Cells;

/// <summary>
///     Base class for a cell in the map.
/// </summary>
public abstract class Cell
{
    /// <summary>
    ///     Initializes a new instance of the Cell class.
    /// </summary>
    /// <param name="x"> X position of the cell in the map. </param>
    /// <param name="y"> Y position of the cell in the map. </param>
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