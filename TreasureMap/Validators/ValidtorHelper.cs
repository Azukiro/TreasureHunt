using System.ComponentModel.DataAnnotations;
using TreasureMap.Attribute;
using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Validators;

/// <summary>
/// Helper class to validate entities.
/// </summary>
public static class ValidatorHelper
{
    /// <summary>
    /// Validates an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="mapService"></param>
    /// <param name="stateService"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static List<ValidationResult> Validate<T>(T entity, IMapService mapService, IStateService stateService) where T : class
    {
        if(entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        var validationResults = new List<ValidationResult>();
        var services = new Dictionary<Type, object>
        {
            { typeof(IMapService), mapService },
            { typeof(IStateService), stateService }
        };

        var validationContext = new ValidationContext(entity, new SimpleServiceProvider(services), null);

        Validator.TryValidateObject(entity, validationContext, validationResults, true);
        
        return validationResults;
    }
}
