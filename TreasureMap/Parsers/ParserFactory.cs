using TreasureMap.Attribute;
using TreasureMap.Parsers.DataParsers;
using TreasureMap.Utils;

namespace TreasureMap.Parsers;

/// <summary>
///     Factory class for creating a parser based on the model type
/// </summary>
public static class ParserFactory
{
    /// <summary>
    ///     Get the parser for the model type.
    /// </summary>
    /// <param name="modelType"> Type of the model to be parsed. </param>
    /// <returns></returns>
    public static IDataParser GetParser(Type modelType)
    {
        return AttributeFactory.GetInstance<IDataParser, ParsableAttribute>(modelType);
    }
}