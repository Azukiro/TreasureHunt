using TreasureMap.Attribute;
using TreasureMap.Enums;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
/// Class responsible for parsing adventurers.
/// </summary>
[Parsable(typeof(Adventurer))]
public class AdventurerParser : IDataParser
{
    /// <summary>
    /// Parse a line into an adventurer and add to the map. 
    /// </summary>
    /// <param name="line"></param>
    /// <exception cref="ParsingException"></exception>
    public void Parse(string[] line, IStateService stateService)
    {
        try
        {
            var name = line[1];
            var x = int.Parse(line[2]);
            var y = int.Parse(line[3]);
            var orientation = Enum.Parse<Orientation>(line[4]);
            
            var queue = new Queue<Movement>();
            foreach (var c in line[5])
            {
                queue.Enqueue(Enum.Parse<Movement>(c.ToString()));
            }

            var adventurer = new Adventurer(name, 0, new Position(x, y), orientation, queue);
            stateService.AddAdventurer(adventurer);
        }
        catch (Exception e)
        {
            throw new ParsingException(line, e);
        }
    }
}