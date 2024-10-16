using TreasureMap.Attribute;
using TreasureMap.Constants;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Utils;

namespace TreasureMap.Writers.DataWriters;

/// <summary>
/// Class to write the map data.
/// </summary>
[Writable(typeof(BoundingBox))]
public class MapDataWriter : IDataWriter, ISingleton
{
    private static MapDataWriter? _instance;
    
    private MapDataWriter()
    {
    }
    
    public static ISingleton GetInstance()
    {
        return _instance ??= new MapDataWriter();
    }
    
    
    public string Write(object data)
    {
        if (data is not BoundingBox boundingBox)
        {
            throw new WriterBadTypeException<BoundingBox>(typeof(object));
        }
        return $"{IoConstants.BoundingBox}{IoConstants.Separator}{boundingBox.Width}{IoConstants.Separator}{boundingBox.Height}\n";
    }
}