using TreasureMap.Attribute;
using TreasureMap.Constants;
using TreasureMap.Exceptions;
using TreasureMap.Models.Cells;
using TreasureMap.Utils;

namespace TreasureMap.Writers.DataWriters;

/// <summary>
/// Class to write the mountain cell data.
/// </summary>
[Writable(typeof(MountainCell))]
public class MountainCellDataWriter : IDataWriter, ISingleton
{
    
    private static MountainCellDataWriter? _instance;
    
    private MountainCellDataWriter()
    {
    }
    
    public static ISingleton GetInstance()
    {
        return _instance ??= new MountainCellDataWriter();
    }
    
    public string Write(object data)
    {
        if (data is not MountainCell mountainCell)
        {
            throw new WriterBadTypeException<MountainCell>(typeof(object));
        }
        return $"{IoConstants.Mountain}{IoConstants.Separator}{mountainCell.Position.X}{IoConstants.Separator}{mountainCell.Position.Y}\n";
    }
}