namespace TreasureMap.Models;

/// <summary>
///  Class representing a position on the map.
/// </summary>
public class Position
{
    /// <summary>
    /// X coordinates of the position.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y coordinates of the position.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Constructor of the position.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}