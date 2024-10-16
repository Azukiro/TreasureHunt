using TreasureMap.Attribute;
using TreasureMap.Models;
using TreasureMap.Parsers.DataParsers;
using TreasureMap.Utils;

namespace TreasureMap.Parsers;

/// <summary>
///  Factory class for creating a parser based on the model type
/// </summary>
public static class ParserFactory
{
    public static IDataParser GetParser(Type modelType)
    {
        return (IDataParser)AttributeFactory.GetInstance<ParsableAttribute>(modelType);
    }
}