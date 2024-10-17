using TreasureMap.Services;
using TreasureMap.Stategies;
using TreasureMap.Utils;

//Initialize files
var map = FileHelper.Read(args[0]);
var outputPath = args[1];

//Initialize the services
IStateService stateService = StateService.Instance;
IMapService mapService = new MapService(stateService);
IMovementStrategy moveForwardStrategy = new MoveForwardStrategy(mapService, stateService);
IMovementStrategy turnRightStrategy = new TurnRightStrategy();
IMovementStrategy turnLeftStrategy = new TurnLeftStrategy();
SimulationService simulationService =
    new(mapService, stateService, moveForwardStrategy, turnRightStrategy, turnLeftStrategy);

//Play the simulation
simulationService.Load(map);
simulationService.Launch();
var save = simulationService.Save();

//Write the output
FileHelper.Write(outputPath, save);
Console.WriteLine($"The output file is available at: {Path.GetFullPath(outputPath)}");

//Wait 
Console.ReadLine();