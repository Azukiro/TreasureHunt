using System.ComponentModel.DataAnnotations;
using TreasureMap.Attribute;
using TreasureMap.Enums;
using TreasureMap.Exceptions;
using TreasureMap.Parsers;
using TreasureMap.Validators.Attribute;
using TreasureMap.Writers;

namespace TreasureMap.Models;

/// <summary>
/// Class representing an adventurer.
/// </summary>
public class Adventurer
{
    /// <summary>
    ///  Constructor of the adventurer.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="treasureCount"></param>
    /// <param name="position"></param>
    /// <param name="orientation"></param>
    /// <param name="movements"></param>
    public Adventurer(string name, int treasureCount, Position position, Orientation orientation, Queue<Movement> movements)
    {
        Name = name;
        TreasureCount = treasureCount;
        Position = position;
        Orientation = orientation;
        Movements = movements;
    }

    public Adventurer()
    {
    }

    /// <summary>
    /// Adventurer's name.
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    ///  Number of treasures collected by the adventurer.
    /// </summary>
    public int TreasureCount { get; set; }
    
    /// <summary>
    /// Position of the adventurer on the map.
    /// </summary>
    [Required]
    [PositionInMap]
    public Position Position { get; set; }
    
    /// <summary>
    /// Orientation of the adventurer.
    /// </summary>
    [NotBe(Orientation.None)]
    public Orientation Orientation { get; set; } = Orientation.None;
    
    /// <summary>
    /// Movements to be performed by the adventurer.
    /// </summary>
    [Required]
    [EnumerableLength(1, int.MaxValue)]
    public Queue<Movement> Movements { get; set; }

}