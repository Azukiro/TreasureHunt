using TreasureMap.Enums;
using TreasureMap.Validators.Attribute;

namespace TreasureMap.Models;

/// <summary>
///     Class representing an adventurer.
/// </summary>
public class Adventurer
{
    /// <summary>
    ///     Initializes a new instance of the Adventurer class.
    /// </summary>
    /// <param name="name"> The name of the adventurer. Must not be null or empty. </param>
    /// <param name="position"> The initial position of the adventurer. It must be unique and within the bounds of the map. </param>
    /// <param name="orientation"> The initial orientation of the adventurer. </param>
    /// <param name="movements">
    ///     The sequence of movements the adventurer will execute. It must not be null and should include
    ///     at least one movement.
    /// </param>
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