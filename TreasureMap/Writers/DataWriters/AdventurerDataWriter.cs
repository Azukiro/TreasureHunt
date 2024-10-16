using TreasureMap.Attribute;
using TreasureMap.Constants;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Utils;

namespace TreasureMap.Writers.DataWriters;

[Writable(typeof(Adventurer))]
public class AdventurerDataWriter : IDataWriter
{
    private static AdventurerDataWriter? _instance;
    
    private AdventurerDataWriter()
    {
    }
    
    public static ISingleton GetInstance()
    {
        return _instance ??= new AdventurerDataWriter();
    }
    
    public string Write(object data)
    {
        if(data is not Adventurer adventurer)
        {
            throw new WriterBadTypeException<Adventurer>(typeof(object));
        }
        
        return $"{IoConstants.Adventurer}{IoConstants.Separator}{adventurer.Name}{IoConstants.Separator}{adventurer.Position.X}{IoConstants.Separator}{adventurer.Position.Y}{IoConstants.Separator}{adventurer.Orientation}{IoConstants.Separator}{adventurer.TreasureCount}\n";
        
    }
}