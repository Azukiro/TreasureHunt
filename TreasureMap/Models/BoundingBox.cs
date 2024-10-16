using TreasureMap.Attribute;
using TreasureMap.Parsers;
using TreasureMap.Writers;

namespace TreasureMap.Models;

/// <summary>
/// Class representing the bounding map.
/// </summary>
public class BoundingBox
{
    /// <summary>
    /// Width of the bounding map.
    /// </summary>
    public int Width { get; }
    
    /// <summary>
    /// Height of the bounding map.
    /// </summary>
    public int Height { get; }
    
    /// <summary>
    /// Constructor of the bounding map.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public BoundingBox(int width, int height)
    {
        Width = width;
        Height = height;
    }
}