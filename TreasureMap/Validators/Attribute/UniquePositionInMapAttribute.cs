using System.ComponentModel.DataAnnotations;
using TreasureMap.Models;
using TreasureMap.Services;

namespace TreasureMap.Validators.Attribute;

/// <summary>
///     Attribute to validate that a position is unique in the map.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class UniquePositionInMap : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is Position position)
        {
            var stateService = (IStateService?) validationContext.GetService(typeof(IStateService));
            if (stateService == null) return new ValidationResult("State service not available.");

            if (stateService.GetCells().Where(c => !ReferenceEquals(c.Position, value))
                .Any(c => c.Position.X == position.X && c.Position.Y == position.Y))
                return new ValidationResult($"Position ({position.X}, {position.Y}) is already taken.");
        }

        return ValidationResult.Success;
    }
}