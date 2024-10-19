using TreasureMap;
using TreasureMap.Utils;

if (args.Length < 2)
{
    LoggerHelper.LogError(
        "You must provide an input file path and an output file path. Example: TreasureMap.exe input.txt output.txt");
    return;
}


try
{
    SimulationRunner.Run(args[0], args[1]);
}
catch (Exception e)
{
    LoggerHelper.LogError(e, "An error occurred during the simulation :");
}

// Wait for user input to close the console
Console.ReadLine();