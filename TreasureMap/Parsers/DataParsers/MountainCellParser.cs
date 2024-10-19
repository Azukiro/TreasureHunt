using TreasureMap.Attribute;
using TreasureMap.Exceptions;
using TreasureMap.Models.Cells;
using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Class responsible for parsing mountain cells.
/// </summary>
[Parsable(typeof(MountainCell))]
public class MountainCellParser : IDataParser
{
    /// <summary>
    ///     Parse a line into a mountain cell and add to the map.
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
            stateService.AddCell(new MountainCell(x, y));
        }
        catch (Exception e)
        {
            throw new ParsingException(lineData, e);
        }
    }
}