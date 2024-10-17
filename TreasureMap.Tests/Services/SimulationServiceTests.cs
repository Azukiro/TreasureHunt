using Moq;
using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Services;
using TreasureMap.Stategies;

namespace TreasureMap.Tests.Services;

public class SimulationServiceTests
{
    private readonly Mock<IMovementStrategy> _mockMoveForwardStrategy;
    private readonly Mock<IStateService> _mockStateService;
    private readonly Mock<IMovementStrategy> _mockTurnRightStrategy;
    private readonly SimulationService _simulationService;

    public SimulationServiceTests()
    {
        Mock<IMapService> mockMapService = new();
        _mockStateService = new Mock<IStateService>();

        _mockMoveForwardStrategy = new Mock<IMovementStrategy>();
        _mockTurnRightStrategy = new Mock<IMovementStrategy>();
        Mock<IMovementStrategy> mockTurnLeftStrategy = new();

        _simulationService = new SimulationService(mockMapService.Object, _mockStateService.Object,
            _mockMoveForwardStrategy.Object, _mockTurnRightStrategy.Object, mockTurnLeftStrategy.Object);
    }

    [Fact]
    public void Launch_Should_Execute_Movements_For_Adventurer()
    {
        // Arrange
        var adventurer = new Adventurer("Christophe", new Position(1, 1), Orientation.S,
            new Queue<Movement>(new[] {Movement.A, Movement.A, Movement.D, Movement.A}));
        _mockStateService.Setup(s => s.GetAdventurers()).Returns([adventurer]);

        // Act
        _simulationService.Launch();

        // Assert
        _mockMoveForwardStrategy.Verify(s => s.Execute(adventurer), Times.Exactly(3));
        _mockTurnRightStrategy.Verify(s => s.Execute(adventurer), Times.Once);
    }

    [Fact]
    public void Load_Should_Parse_Map_Correctly()
    {
        // Arrange
        var map = @"
C - 3 - 4
M - 1 - 0
M - 2 - 1
T - 0 - 3 - 2
T - 1 - 3 - 3
A - Lara - 1 - 1 - S - AADADAGGA";

        // Act
        _simulationService.Load(map);

        // Assert
        _mockStateService.Verify(s => s.AddAdventurer(It.IsAny<Adventurer>()), Times.Once);
        _mockStateService.Verify(s => s.AddCell(It.IsAny<Cell>()), Times.Exactly(4));
    }

    [Fact]
    public void Save_Should_Export_Result_To_Console()
    {
        // Arrange
        var adventurer = new Adventurer("Edward", new Position(0, 3), Orientation.S, new Queue<Movement>());

        var treasureCell = new TreasureCell(0, 3, 3);
        var mountainCell = new MountainCell(1, 0);

        var boundingBox = new BoundingBox(3, 4);

        _mockStateService.Setup(s => s.GetAdventurers()).Returns([adventurer]);
        _mockStateService.Setup(s => s.GetCells()).Returns([treasureCell, mountainCell]);
        _mockStateService.Setup(s => s.GetBoundingBox()).Returns(boundingBox);

        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        _simulationService.Save();

        // Assert
        var result = consoleOutput.ToString();
        Assert.Contains("C - 3 - 4", result);
        Assert.Contains("M - 1 - 0", result);
        Assert.Contains("T - 0 - 3 - 3", result);
        Assert.Contains("A - Lara - 0 - 3 - S - 0", result);
    }
}