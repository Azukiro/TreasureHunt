using TreasureMap.Services;
using TreasureMap.Stategies;
using TreasureMap.Utils;

namespace TreasureMap;

public static class SimulationRunner
{
    public static void Run(string inputFilePath, string outputFilePath)
    {
        // Init map
        var map = FileHelper.Read(inputFilePath);

        // Init services
        IStateService stateService = StateService.Instance;
        IMapService mapService = new MapService(stateService);
        IMovementStrategy moveForwardStrategy = new MoveForwardStrategy(mapService, stateService);
        IMovementStrategy turnRightStrategy = new TurnRightStrategy();
        IMovementStrategy turnLeftStrategy = new TurnLeftStrategy();
        SimulationService simulationService = new(
            mapService, stateService, moveForwardStrategy, turnRightStrategy, turnLeftStrategy
        );

        // Launch simulation
        simulationService.Load(map);
        simulationService.Launch();
        var save = simulationService.Save();

        // Write in output file
        FileHelper.Write(outputFilePath, save);
        Console.WriteLine($"The output file is available at: {Path.GetFullPath(outputFilePath)}");
    }
}