using TreasureMap;

if (args.Length < 2)
{
    Console.WriteLine("Usage: <inputFilePath> <outputFilePath>");
    return;
}

SimulationRunner.Run(args[0], args[1]);

// Wait for user input to close the console
Console.ReadLine();