using TreasureMap.Enums;
using TreasureMap.Models.Cells;
using TreasureMap.Services;
using TreasureMap.Stategies.AdventurerCanEnterStrategies;
using TreasureMap.Stategies.AdventurerEnterStrategies;
using TreasureMap.Stategies.MovementStategies;
using TreasureMap.Utils;

namespace TreasureMap;

public static class SimulationRunner
{
    public static void Run(string inputFilePath, string outputFilePath)
    {
        LoggerHelper.LogInfo("Simulation started");

        // Init map
        var map = FileHelper.Read(inputFilePath);

        // Init services
        var simulationService = InitSimulationService();

        LoggerHelper.LogInfo("Loading map...");
        simulationService.Load(map);

        LoggerHelper.LogInfo("Launching simulation...");
        simulationService.Launch();

        LoggerHelper.LogInfo("Simulation ended");

        LoggerHelper.LogInfo("Saving simulation...");
        var save = simulationService.Save();
        FileHelper.Write(outputFilePath, save);

        LoggerHelper.LogInfo($"The output file is available at: {Path.GetFullPath(outputFilePath)}");
    }

    private static SimulationService InitSimulationService()
    {
        var adventurerEnterStrategyContext = InitAdventurerEnterStrategyContext();

        var adventurerCanEnterStrategyContext = AdventurerCanEnterStrategyContext();

        IStateService stateService = StateService.Instance;

        IMapService mapService = new MapService(stateService, adventurerCanEnterStrategyContext);

        var movementStrategyContext =
            InitMovementStrategyContext(mapService, stateService, adventurerEnterStrategyContext);

        SimulationService simulationService = new(
            mapService, stateService, movementStrategyContext
        );

        return simulationService;
    }

    private static MovementStrategyContext InitMovementStrategyContext(IMapService mapService,
        IStateService stateService,
        AdventurerEnterStrategyContext adventurerEnterStrategyContext)
    {
        MovementStrategyContext movementStrategyContext = new(new Dictionary<Movement, IMovementStrategy>
        {
            {Movement.A, new MoveForwardStrategy(mapService, stateService, adventurerEnterStrategyContext)},
            {Movement.D, new TurnRightStrategy()},
            {Movement.G, new TurnLeftStrategy()}
        });
        return movementStrategyContext;
    }

    private static AdventurerCanEnterStrategyContext AdventurerCanEnterStrategyContext()
    {
        AdventurerCanEnterStrategyContext adventurerCanEnterStrategyContext = new(
            new Dictionary<Type, IAdventurerCanEnterStrategy>
            {
                {typeof(MountainCell), new MountainCellAdventurerCanEnterStrategy()}
            });
        return adventurerCanEnterStrategyContext;
    }

    private static AdventurerEnterStrategyContext InitAdventurerEnterStrategyContext()
    {
        return new AdventurerEnterStrategyContext(new Dictionary<Type, IAdventurerEnterStrategy>
        {
            {typeof(TreasureCell), new TreasureCellAdventurerEnterStrategy()}
        });
    }
}