using System.ComponentModel.DataAnnotations;

namespace TreasureMap.Models;

/// <summary>
///     Class representing the bounding map.
/// </summary>
public class BoundingBox
{
    /// <summary>
    ///     Initializes a new instance of the bounding map class.
    /// </summary>
    /// <param name="width"> Width of the bounding map. Must be greater than 1</param>
    /// <param name="height"> Height of the bounding map. Must be greater than 1</param>
    public BoundingBox(int width, int height)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    ///     Width of the bounding map.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Width must be greater than 0.")]
    public int Width { get; }

    /// <summary>
    ///     Height of the bounding map.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Height must be greater than 0.")]
    public int Height { get; }
}