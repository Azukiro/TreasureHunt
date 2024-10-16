
using TreasureMap.Exceptions;
using TreasureMap.Parsers;
using TreasureMap.Attribute;
namespace TreasureMap.Models.Cells;

/// <summary>
/// Class representing a mountain cell.
/// </summary>
public class MountainCell : Cell
{
    /// <inheritdoc />
    public MountainCell(int x, int y) : base(x, y)
    {
    }
    
    public override bool CanMoveTo()
    {
        return false;
    }
    
    public override void MoveTo(Adventurer adventurer)
    {
        throw new RestrictedCellException("Adventurer cannot move to a mountain cell.");
    }

}