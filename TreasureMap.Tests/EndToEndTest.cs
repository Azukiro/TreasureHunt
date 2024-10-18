using TreasureMap.Services;

namespace TreasureMap.Tests;

public class EndToEndTest
{
    [Theory]
    [InlineData("SimpleMovement.txt")]
    [InlineData("MountainBlocked.txt")]
    [InlineData("TwoPlayer.txt")]
    [InlineData("CollectAllTreasure.txt")]
    [InlineData("Complex.txt")]
    public void Main_EndToEndTest(string fileName)
    {
        // Arrange
        StateService.Instance.Reset();
        var inputFilePath = $"./Assets/Input/{fileName}";
        var expectedOutputFilePath = $"./Assets/Output/{fileName}";

        var outputFilePath = Path.GetTempFileName();

        // Act: 
        SimulationRunner.Run(inputFilePath, outputFilePath);

        // Assert:
        Assert.True(File.Exists(outputFilePath), "The output file should be created");

        var actualOutput = File.ReadAllText(outputFilePath).Trim();
        var expectedOutput = File.ReadAllText(expectedOutputFilePath).Trim();
        Assert.Equal(expectedOutput.Trim(), actualOutput);
    }
}