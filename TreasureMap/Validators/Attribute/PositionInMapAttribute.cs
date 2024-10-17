using System.ComponentModel.DataAnnotations;
using TreasureMap.Models;
using TreasureMap.Services;

namespace TreasureMap.Validators.Attribute;

/// <summary>
///     Attribute to validate that a position is inside the map.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class PositionInMap : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is Position position)
        {
            var mapService = (IMapService?) validationContext.GetService(typeof(IMapService));
            if (mapService == null) return new ValidationResult("Map service not available.");

            if (!mapService.IsInsideMap(position))
                return new ValidationResult($"Position ({position.X}, {position.Y}) is out of bounds.");
        }

        return ValidationResult.Success;
    }
}