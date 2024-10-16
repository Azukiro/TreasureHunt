using System.Reflection;
using TreasureMap.Attribute;
using TreasureMap.Utils;
using TreasureMap.Writers.DataWriters;

namespace TreasureMap.Writers;

public static class WriterFactory
{
    public static IDataWriter GetWriter(Type modelType)
    {
        return (IDataWriter)AttributeFactory.GetInstance<WritableAttribute>(modelType);
    }
}