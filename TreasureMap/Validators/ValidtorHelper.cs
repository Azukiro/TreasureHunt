﻿using System.ComponentModel.DataAnnotations;
using TreasureMap.Services;
using TreasureMap.Utils;

namespace TreasureMap.Validators;

/// <summary>
///     Helper class to validate entities.
/// </summary>
public static class ValidatorHelper
{
    /// <summary>
    ///     Validates an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="mapService"></param>
    /// <param name="stateService"></param>
    /// <typeparam name="T"> Type of the entity. </typeparam>
    /// <returns> List of validation results. </returns>
    /// <exception cref="ArgumentNullException"> Thrown when the entity is null. </exception>
    public static List<ValidationResult> Validate<T>(T entity, IMapService mapService, IStateService stateService)
        where T : class
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        List<ValidationResult> validationResults = [];
        var services = new Dictionary<Type, object>
        {
            {typeof(IMapService), mapService},
            {typeof(IStateService), stateService}
        };

        var validationContext = new ValidationContext(entity, new SimpleServiceProvider(services), null);

        Validator.TryValidateObject(entity, validationContext, validationResults, true);

        return validationResults;
    }
}