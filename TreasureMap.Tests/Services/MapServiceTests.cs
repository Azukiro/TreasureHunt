using System.ComponentModel.DataAnnotations;
using Moq;
using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Services;
using TreasureMap.Stategies.AdventurerCanEnterStrategies;

namespace TreasureMap.Tests.Services;

public class MapServiceTests
{
    private readonly MapService _mapService;
    private readonly Mock<IAdventurerCanEnterStrategy> _mockMountainCellAdventurerCanEnterStrategy;
    private readonly Mock<IStateService> _stateServiceMock;

    public MapServiceTests()
    {
        _stateServiceMock = new Mock<IStateService>();

        _mockMountainCellAdventurerCanEnterStrategy = new Mock<IAdventurerCanEnterStrategy>();
        AdventurerCanEnterStrategyContext adventurerCanEnterStrategyContext = new(
            new Dictionary<Type, IAdventurerCanEnterStrategy>
            {
                {typeof(MountainCell), _mockMountainCellAdventurerCanEnterStrategy.Object}
            });

        _mapService = new MapService(_stateServiceMock.Object, adventurerCanEnterStrategyContext);
    }

    [Theory]
    [InlineData(2, 3, 5, 5, true)] // Position (2, 3) within bounds
    [InlineData(4, 4, 5, 5, true)] // Position (4, 4) within bounds
    [InlineData(5, 5, 5, 5, false)] // Position (5, 5) on the edge
    [InlineData(-1, 0, 5, 5, false)] // Position (-1, 0) out of bounds
    [InlineData(6, 2, 5, 5, false)] // Position (6, 2) out of bounds
    public void IsInsideMap_ShouldReturnExpectedResult_WhenPositionIsChecked(int x, int y, int width, int height,
        bool expectedResult)
    {
        // Arrange
        var position = new Position(x, y);
        var boundingBox = new BoundingBox(width, height);
        _stateServiceMock.Setup(s => s.GetBoundingBox()).Returns(boundingBox);

        // Act
        var result = _mapService.IsInsideMap(position);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ValidateCells_ShouldThrowValidationException_WhenValidationPositionFails()
    {
        // Arrange
        var mountainCell = new MountainCell(1, 1);
        var treasureCell = new TreasureCell(4, 4, 1);
        List<ValidationResult> validationResults =
            [new($"Position ({treasureCell.Position.X}, {treasureCell.Position.Y}) is out of bounds.")];

        _stateServiceMock.Setup(s => s.GetCells()).Returns((List<Cell>) [mountainCell, treasureCell]);
        _stateServiceMock.Setup(s => s.GetAdventurers()).Returns([]);
        _stateServiceMock.Setup(s => s.GetBoundingBox()).Returns(new BoundingBox(2, 2));

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => _mapService.ValidateMap());
        foreach (var validationResult in validationResults)
            if (validationResult.ErrorMessage != null)
                Assert.Contains(validationResult.ErrorMessage, ex.Message);
    }

    [Fact]
    public void ValidateTreasureCells_ShouldThrowValidationException_WhenValidationTreasureCountFails()
    {
        // Arrange
        var treasureCellNegative = new TreasureCell(1, 1, -1);
        var treasureCell = new TreasureCell(1, 2, 1);
        List<ValidationResult> validationResults = [new("Treasure count must be greater than 0.")];

        _stateServiceMock.Setup(s => s.GetCells()).Returns((List<Cell>) [treasureCellNegative, treasureCell]);
        _stateServiceMock.Setup(s => s.GetAdventurers()).Returns([]);
        _stateServiceMock.Setup(s => s.GetBoundingBox()).Returns(new BoundingBox(2, 2));

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => _mapService.ValidateMap());
        foreach (var validationResult in validationResults)
            if (validationResult.ErrorMessage != null)
                Assert.Contains(validationResult.ErrorMessage, ex.Message);
    }

    [Fact]
    public void ValidateCells_ShouldThrowValidationException_WhenValidationUniquePositionFails()
    {
        // Arrange
        var mountainCell = new MountainCell(1, 1);
        var treasureCell = new TreasureCell(1, 1, 1);
        List<ValidationResult> validationResults =
            [new($"Position ({treasureCell.Position.X}, {treasureCell.Position.Y}) is already taken.")];

        _stateServiceMock.Setup(s => s.GetCells()).Returns((List<Cell>) [mountainCell, treasureCell]);
        _stateServiceMock.Setup(s => s.GetAdventurers()).Returns([]);
        _stateServiceMock.Setup(s => s.GetBoundingBox()).Returns(new BoundingBox(2, 2));

        // Act & Assert
        var ex = Assert.Throws<ValidationException>(() => _mapService.ValidateMap());
        foreach (var validationResult in validationResults)
            if (validationResult.ErrorMessage != null)
                Assert.Contains(validationResult.ErrorMessage, ex.Message);
    }


    [Theory]
    [InlineData(2, 3, true)] // Position (2, 3) is valid
    [InlineData(2, 4, false)] // Position (2, 4) is a mountain
    [InlineData(1, 1, false)] // Position (1, 1) is already occupied
    [InlineData(6, 6, false)] // Position (6, 6) is out of bounds
    public void CanMoveAdventurer_ShouldReturnFalse_WhenMoveIsInvalid(int newPositionX, int newPositionY,
        bool expectedResult)
    {
        // Arrange
        Adventurer adventurer = new("Edward", new Position(newPositionX - 1, newPositionY), Orientation.N,
            new Queue<Movement>());
        var potentialPosition = new Position(newPositionX, newPositionY);

        List<Cell> cells = [new MountainCell(2, 4)];

        List<Adventurer> adventurers =
        [
            adventurer,
            new("Christophe", new Position(1, 1), Orientation.N, new Queue<Movement>())
        ];

        _stateServiceMock.Setup(s => s.GetCell(new Position(2, 4))).Returns(cells[0]);
        _stateServiceMock.Setup(s => s.GetAdventurers()).Returns(adventurers);
        _stateServiceMock.Setup(s => s.GetBoundingBox()).Returns(new BoundingBox(5, 5));
        _mockMountainCellAdventurerCanEnterStrategy.Setup(s => s.Execute(adventurer, cells[0])).Returns(false);

        // Act
        var result = _mapService.CanMoveAdventurer(adventurer, potentialPosition);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}