using TreasureMap.Services;
using TreasureMap.Stategies;

var map = "C - 3 - 4\n" +
          "M - 1 - 0\n" +
          "M - 2 - 1\n" +
          "T - 0 - 3 - 2\n" +
          "T - 1 - 3 - 3\n" +
          "A - Lara - 1 - 1 - S - AADADAGGA";

//Initialize the services
IStateService stateService = StateService.Instance;

IMapService mapService = new MapService(stateService);
IMovementStrategy moveForwardStrategy = new MoveForwardStrategy(mapService, stateService);
IMovementStrategy turnRightStrategy = new TurnRightStrategy();
IMovementStrategy turnLeftStrategy = new TurnLeftStrategy();
SimulationService simulationService = new(mapService, stateService, moveForwardStrategy, turnRightStrategy, turnLeftStrategy);

//Play the simulation
simulationService.Load(map);
simulationService.Launch();
simulationService.Save();

//Wait 
Console.ReadLine();
