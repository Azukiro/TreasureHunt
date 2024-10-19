using System.ComponentModel.DataAnnotations;
using TreasureMap.Models;
using TreasureMap.Stategies.AdventurerCanEnterStrategies;
using TreasureMap.Validators;

namespace TreasureMap.Services;

/// <summary>
///     Service for the management of the map.
/// </summary>
public class MapService(
    IStateService stateService,
    AdventurerCanEnterStrategyContext adventurerCanEnterStrategyContext) : IMapService
{
    #region BusinessLogic

    public bool IsInsideMap(Position position)
    {
        var boundingBox = stateService.GetBoundingBox();

        return position.X >= 0 && position.X < boundingBox.Width && position.Y >= 0 && position.Y < boundingBox.Height;
    }

    public void ValidateMap()
    {
        var cells = stateService.GetCells();
        var adventurers = stateService.GetAdventurers();

        List<ValidationResult> validationResults = [];
        validationResults.AddRange(
            cells.SelectMany(c => ValidatorHelper.Validate(c, this, stateService)
            ));
        validationResults.AddRange(
            adventurers.SelectMany(c => ValidatorHelper.Validate(c, this, stateService)
            ));

        if (validationResults.Count > 0) throw new ValidationException(string.Join(", ", validationResults));
    }


    public bool CanMoveAdventurer(Adventurer adventurer, Position potentialPosition)
    {
        var adventurers = stateService.GetAdventurers();

        var isInsideMap = IsInsideMap(potentialPosition);

        var adventurerOnCase = adventurers.Where(a => a.Name != adventurer.Name)
            .Any(a => a.Position.X == potentialPosition.X && a.Position.Y == potentialPosition.Y);

        var cell = stateService.GetCell(potentialPosition);
        var canEnter = cell == null || adventurerCanEnterStrategyContext.ExecuteStrategy(adventurer, cell);

        return canEnter && isInsideMap && !adventurerOnCase;
    }

    #endregion
}