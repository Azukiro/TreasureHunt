using TreasureMap.Parsers;
using TreasureMap.Stategies.MovementStategies;
using TreasureMap.Writers;

namespace TreasureMap.Services;

/// <summary>
///     Service for the simulation.
/// </summary>
public class SimulationService(
    IMapService mapService,
    IStateService stateService,
    MovementStrategyContext movementStrategyContext)
    : ISimulationService
{
    public void Load(string map)
    {
        var parser = new TreasureMapParser(mapService, stateService);
        parser.Parse(map.Split(Environment.NewLine));
    }

    public void Launch()
    {
        var adventurers = stateService.GetAdventurers();
        while (adventurers.Any(adventurer => adventurer.Movements.Any()))
            foreach (var adventurer in adventurers.Where(adventurer => adventurer.Movements.Any()))
            {
                var movement = adventurer.Movements.Dequeue();
                movementStrategyContext.ExecuteStrategy(movement, adventurer);
            }
    }

    public string Save()
    {
        Writer writer = new(stateService);
        return writer.ExportResult();
    }
}