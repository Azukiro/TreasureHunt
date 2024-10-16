using TreasureMap.Attribute;
using TreasureMap.Constants;
using TreasureMap.Exceptions;
using TreasureMap.Models.Cells;
using TreasureMap.Utils;

namespace TreasureMap.Writers.DataWriters;

/// <summary>
/// Class to write the treasure cell data.
/// </summary>
[Writable(typeof(TreasureCell))]
public class TreasureCellDataWriter : IDataWriter, ISingleton
{
    private static TreasureCellDataWriter? _instance;
    
    private TreasureCellDataWriter()
    {
    }
    
    public static ISingleton GetInstance()
    {
        return _instance ??= new TreasureCellDataWriter();
    }
    public string Write(object data)
    {
        if (data is not TreasureCell treasureCell)
        {
            throw new WriterBadTypeException<TreasureCell>(typeof(object));
        }
        
        if(treasureCell.TreasureCount == 0)
        {
            return string.Empty;
        }
            
        return $"{IoConstants.Treasure}{IoConstants.Separator}{treasureCell.Position.X}{IoConstants.Separator}{treasureCell.Position.Y}{IoConstants.Separator}{treasureCell.TreasureCount}\n";
        
    }
}