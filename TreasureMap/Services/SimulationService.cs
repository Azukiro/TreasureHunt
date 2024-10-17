using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Parsers;
using TreasureMap.Stategies;
using TreasureMap.Writers;

namespace TreasureMap.Services;

/// <summary>
/// Service for the simulation.
/// </summary>
public class SimulationService(
    IMapService mapService,
    IStateService stateService,
    IMovementStrategy moveForwardStrategy,
    IMovementStrategy turnRightStrategy,
    IMovementStrategy turnLeftStrategy)
    : ISimulationService
{

    /// <summary>
    /// The strategies for the movements.
    /// </summary>
    private readonly Dictionary<Movement, IMovementStrategy> _strategies = new()
    {
        { Movement.A, moveForwardStrategy },
        { Movement.D, turnRightStrategy },
        { Movement.G, turnLeftStrategy }
    };

    public void Load(string map)
    {
        var parser = new TreasureMapParser(mapService,stateService);
        parser.Parse(map.Split('\n'));
    }

    public void Launch()
    {
        var adventurers = stateService.GetAdventurers();
        while(adventurers.Any(adventurer => adventurer.Movements.Any()))
        {
            foreach (var adventurer in adventurers)
            {
                var movement = adventurer.Movements.Dequeue();
                if (_strategies.TryGetValue(movement, out var strategy))
                {
                    strategy.Execute(adventurer);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
    }

    public void Save()
    {
        Writer writer = new(stateService);
        Console.WriteLine(writer.ExportResult());
    }
}