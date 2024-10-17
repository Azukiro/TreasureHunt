using TreasureMap.Enums;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Services;

namespace TreasureMap.Tests.Services;

public class StateServiceTests
{
    private readonly IStateService _stateService = StateService.Instance;

    [Fact]
    public void AddCell_Should_Add_Cell_To_Map()
    {
        // Arrange
        _stateService.Reset();
        var cell = new TreasureCell(0, 0, 1);

        // Act
        _stateService.AddCell(cell);
        var result = _stateService.GetCell(new Position(0, 0));

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cell, result);
    }

    [Fact]
    public void AddAdventurer_Should_Add_Adventurer_To_Map()
    {
        // Arrange
        _stateService.Reset();
        var adventurer = new Adventurer("Lara", new Position(1, 1), Orientation.N, new Queue<Movement>());

        // Act
        _stateService.AddAdventurer(adventurer);
        var result = _stateService.GetAdventurers();

        // Assert
        Assert.Single(result);
        Assert.Equal(adventurer, result[0]);
    }

    [Fact]
    public void GetCell_Should_Return_Null_If_Cell_Does_Not_Exist()
    {
        //Arrange
        _stateService.Reset();

        // Act
        var result = _stateService.GetCell(new Position(5, 5));

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SetBoundingBox_Should_Define_Map_Limits()
    {
        // Arrange
        _stateService.Reset();
        var boundingBox = new BoundingBox(5, 5);

        // Act
        _stateService.SetBoundingBox(boundingBox);
        var result = _stateService.GetBoundingBox();

        // Assert
        Assert.Equal(boundingBox, result);
    }

    [Fact]
    public void GetAdventurers_Should_Return_Empty_If_No_Adventurers()
    {
        //Arrange
        _stateService.Reset();

        // Act
        var result = _stateService.GetAdventurers();

        // Assert
        Assert.Empty(result);
    }
}