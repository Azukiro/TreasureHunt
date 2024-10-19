using TreasureMap.Attribute;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Services;

namespace TreasureMap.Parsers.DataParsers;

/// <summary>
///     Class responsible for parsing the BoudingMap.
/// </summary>
[Parsable(typeof(BoundingBox))]
public class BoundingMapParser : IDataParser
{
    /// <summary>
    ///     Parsing a line into a bounding map and add to the map.
    /// </summary>
    /// <param name="lineData"></param>
    /// <param name="stateService"></param>
    /// <exception cref="ParsingException">Thrown when an error occurs while parsing the line.</exception>
    public void Parse(string[] lineData, IStateService stateService)
    {
        try
        {
            var width = int.Parse(lineData[1]);
            var height = int.Parse(lineData[2]);
            stateService.SetBoundingBox(new BoundingBox(width, height));
        }
        catch (Exception e)
        {
            throw new ParsingException(lineData, e);
        }
    }
}