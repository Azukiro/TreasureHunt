using TreasureMap.Attribute;
using TreasureMap.Exceptions;
using TreasureMap.Models.Cells;
using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Class responsible for parsing treasure cells.
/// </summary>
[Parsable(typeof(TreasureCell))]
public class TreasureCellParser : IDataParser
{
    /// <summary>
    ///     Parse a line into a treasur cell and add to the map.
    /// </summary>
    /// <param name="lineData"></param>
    /// <param name="stateService"></param>
    /// <exception cref="ParsingException">Thrown when an error occurs while parsing the line.</exception>
    public void Parse(string[] lineData, IStateService stateService)
    {
        try
        {
            var x = int.Parse(lineData[1]);
            var y = int.Parse(lineData[2]);
            var treasureCount = int.Parse(lineData[3]);
            stateService.AddCell(new TreasureCell(x, y, treasureCount));
        }
        catch (Exception e)
        {
            throw new ParsingException(lineData, e);
        }
    }
}