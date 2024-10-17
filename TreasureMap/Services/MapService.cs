using System.ComponentModel.DataAnnotations;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Validators;

namespace TreasureMap.Services;

/// <summary>
/// Service for the management of the map.
/// </summary>
public class MapService : IMapService
{
    private readonly StateService _stateService = StateService.GetInstance();
    #region BusinessLogic

    public bool IsInsideMap(Position position)
    {
        var boundingBox = _stateService.GetBoundingBox();
        
        return position.X >= 0 && position.X < boundingBox.Width && position.Y >= 0 && position.Y < boundingBox.Height;
    }

    public void ValidateMap()
    {
        var cells = _stateService.GetCells();
        var adventurers = _stateService.GetAdventurers();
        
        List<ValidationResult> validationResults = new List<ValidationResult>();
        validationResults.AddRange(
            cells.SelectMany(c => ValidatorHelper.Validate(c, this)
            ));
        validationResults.AddRange(
            adventurers.SelectMany(c => ValidatorHelper.Validate(c, this)
            ));

        if (validationResults.Count > 0)
        {
            throw new ValidationException(string.Join(", ", validationResults));
        }
    }


    public bool CanMoveAdventurer(Adventurer adventurer, Position potentialPosition)
    {
        var cells = _stateService.GetCells();
        var adventurers = _stateService.GetAdventurers();
        
        var isInsideMap = IsInsideMap(potentialPosition);
        var adventurerOnCase = adventurers.Where(a => a.Name != adventurer.Name)
            .Any(a => a.Position.X == potentialPosition.X && a.Position.Y == potentialPosition.Y);
        var canMove =
            cells.FirstOrDefault(c => c.Position.X == potentialPosition.X && c.Position.Y == potentialPosition.Y)?.CanMoveTo() ?? false;
        return canMove && isInsideMap && !adventurerOnCase;
    }

    #endregion
}