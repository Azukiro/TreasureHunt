﻿namespace TreasureMap.Models;

/// <summary>
///     Class representing a position on the map.
/// </summary>
public class Position
{
    /// <summary>
    ///     Constructor of the position.
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
    public int X { get; set; }

    /// <summary>
    ///     Y coordinates of the position.
    /// </summary>
    public int Y { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var position = (Position) obj;
        return X == position.X && Y == position.Y;
    }
}