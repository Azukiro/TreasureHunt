// See https://aka.ms/new-console-template for more information

using TreasureMap;
using TreasureMap.Attribute;
using TreasureMap.Parsers;
using TreasureMap.Services;

var map = "C - 3 - 4\n" +
          "M - 1 - 0\n" +
          "M - 2 - 1\n" +
          "T - 0 - 3 - 2\n" +
          "T - 1 - 3 - 3\n" +
          "A - Lara - 1 - 1 - S - AADADAGGA";
          
MapService? mapService = MapService.Instance;
SimulationService simulationService = new(mapService);
simulationService.Load(map);
simulationService.Launch();
simulationService.Save();
//wait 
Console.ReadLine();
