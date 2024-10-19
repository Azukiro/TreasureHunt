namespace TreasureMap.Models;

/// <summary>
///     Class representing a position on the map.
/// </summary>
public class Position
{
    /// <summary>
    ///     Initializes a new instance of the Position class.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    ///     X coordinates of the position.
    /// </summary>
    public int X { get; }

    /// <summary>
    ///     Y coordinates of the position.
    /// </summary>
    public int Y { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var position = (Position) obj;
        return X == position.X && Y == position.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static Position operator +(Position a, Position b)
    {
        return new Position(a.X + b.X, a.Y + b.Y);
    }
}