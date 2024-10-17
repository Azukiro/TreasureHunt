using TreasureMap.Services;

namespace TreasureMap.Writers;

/// <summary>
///     Class to write the result of the Simulation.
/// </summary>
public class Writer(IStateService stateService)
{
    public string ExportResult()
    {
        var result = "";
        var queue = new Queue<object>();
        var boundingBox = stateService.GetBoundingBox();
        queue.Enqueue(boundingBox);

        foreach (var cell in stateService.GetCells()) queue.Enqueue(cell);

        foreach (var adventurer in stateService.GetAdventurers()) queue.Enqueue(adventurer);

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