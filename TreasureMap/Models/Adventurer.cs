using TreasureMap.Enums;
using TreasureMap.Validators.Attribute;

namespace TreasureMap.Models;

/// <summary>
///     Class representing an adventurer.
/// </summary>
public class Adventurer
{
    /// <summary>
    ///     Constructor of the adventurer.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <param name="orientation"></param>
    /// <param name="movements"></param>
    public Adventurer(string name, Position position, Orientation orientation, Queue<Movement> movements)
    {
        Name = name;
        Position = position;
        Orientation = orientation;
        Movements = movements;
    }

    /// <summary>
    ///     Adventurer's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Number of treasures collected by the adventurer.
    /// </summary>
    public int TreasureCollected { get; set; }

    /// <summary>
    ///     Position of the adventurer on the map.
    /// </summary>
    [PositionInMap]
    [UniquePositionInMap]
    public Position Position { get; set; }

    /// <summary>
    ///     Orientation of the adventurer.
    /// </summary>
    public Orientation Orientation { get; set; }

    /// <summary>
    ///     Movements to be performed by the adventurer.
    /// </summary>
    [EnumerableLength(1, int.MaxValue)]
    public Queue<Movement> Movements { get; set; }
}