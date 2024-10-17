using TreasureMap.Services;

namespace TreasureMap.Writers;

/// <summary>
/// Class to write the result of the Simulation.
/// </summary>
public class Writer
{
    private readonly IStateService _mapService;

    public Writer(IStateService mapService)
    {
        _mapService = mapService;
    }

    public string ExportResult()
    {
        var result = "";
        Queue<object> queue = new Queue<object>();
        var boundingBox = _mapService.GetBoundingBox();
        queue.Enqueue(boundingBox);
        
        foreach (var cell in _mapService.GetCells())
        {
            queue.Enqueue(cell);
        }
        
        foreach (var adventurer in _mapService.GetAdventurers())
        {
            queue.Enqueue(adventurer);
        }

        while (queue.Count > 0)
        {
            var obj = queue.Dequeue();
            var type = obj.GetType();
            var writer = WriterFactory.GetWriter(type);
            result += writer.Write(obj);
        }

        return result;


    }
}