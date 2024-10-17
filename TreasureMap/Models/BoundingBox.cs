namespace TreasureMap.Models;

/// <summary>
///     Class representing the bounding map.
/// </summary>
public class BoundingBox
{
    /// <summary>
    ///     Constructor of the bounding map.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public BoundingBox(int width, int height)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    ///     Width of the bounding map.
    /// </summary>
    public int Width { get; }

    /// <summary>
    ///     Height of the bounding map.
    /// </summary>
    public int Height { get; }
}