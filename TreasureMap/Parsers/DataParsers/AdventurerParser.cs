using TreasureMap.Attribute;
using TreasureMap.Enums;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Class responsible for parsing adventurers.
/// </summary>
[Parsable(typeof(Adventurer))]
public class AdventurerParser : IDataParser
{
    /// <summary>
    ///     Parse a line into an adventurer and add to the map.
    /// </summary>
    /// <param name="lineData"></param>
    /// <param name="stateService"></param>
    /// <exception cref="ParsingException"></exception>
    public void Parse(string[] lineData, IStateService stateService)
    {
        try
        {
            var name = lineData[1];
            var x = int.Parse(lineData[2]);
            var y = int.Parse(lineData[3]);
            var orientation = Enum.Parse<Orientation>(lineData[4]);

            var queue = new Queue<Movement>();
            foreach (var c in lineData[5]) queue.Enqueue(Enum.Parse<Movement>(c.ToString()));

            var adventurer = new Adventurer(name, new Position(x, y), orientation, queue);
            stateService.AddAdventurer(adventurer);
        }
        catch (Exception e)
        {
            throw new ParsingException(lineData, e);
        }
    }
}