using TreasureMap.Attribute;
using TreasureMap.Constants;
using TreasureMap.Exceptions;
using TreasureMap.Models;

namespace TreasureMap.Writers.DataWriters;

/// <summary>
///     Class to write the map data.
/// </summary>
[Writable(typeof(BoundingBox))]
public class MapDataWriter : IDataWriter
{
    public string Write(object data)
    {
        if (data is not BoundingBox boundingBox) throw new WriterBadTypeException<BoundingBox>(typeof(object));
        return
            $"{IoConstants.BoundingBox}{IoConstants.Separator}{boundingBox.Width}{IoConstants.Separator}{boundingBox.Height}\n";
    }
}