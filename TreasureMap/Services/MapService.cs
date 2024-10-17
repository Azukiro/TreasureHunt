using System.ComponentModel.DataAnnotations;
using TreasureMap.Exceptions;
using TreasureMap.Models;
using TreasureMap.Models.Cells;
using TreasureMap.Validators;

namespace TreasureMap.Services;

/// <summary>
/// Service for the management of the map.
/// </summary>
public class MapService(IStateService stateService) : IMapService
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

        if (validationResults.Count > 0)
        {
            throw new ValidationException(string.Join(", ", validationResults));
        }
    }


    public bool CanMoveAdventurer(Adventurer adventurer, Position potentialPosition)
    {
        var cells = stateService.GetCells();
        var adventurers = stateService.GetAdventurers();
        
        var isInsideMap = IsInsideMap(potentialPosition);
        
        var adventurerOnCase = adventurers.Where(a => a.Name != adventurer.Name)
            .Any(a => a.Position.X == potentialPosition.X && a.Position.Y == potentialPosition.Y);
        
        var canMove =
            cells.FirstOrDefault(c => c.Position.X == potentialPosition.X && c.Position.Y == potentialPosition.Y)?.CanMoveTo() ?? true;
        
        return canMove && isInsideMap && !adventurerOnCase;
    }

    #endregion
}