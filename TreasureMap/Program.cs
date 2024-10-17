using TreasureMap.Services;

var map = "C - 3 - 4\n" +
          "M - 1 - 0\n" +
          "M - 2 - 1\n" +
          "T - 0 - 3 - 2\n" +
          "T - 1 - 3 - 3\n" +
          "A - Lara - 1 - 1 - S - AADADAGGA";

//Initialize the services
IMapService mapService = new MapService();
IStateService stateService = StateService.GetInstance();
SimulationService simulationService = new(mapService, stateService);

//Play the simulation
simulationService.Load(map);
simulationService.Launch();
simulationService.Save();

//Wait 
Console.ReadLine();
