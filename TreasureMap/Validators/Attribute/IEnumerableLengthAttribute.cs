using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TreasureMap.Validators.Attribute;

/// <summary>
///     Attribute to validate the length of an enumerable.
/// </summary>
public class EnumerableLengthAttribute : ValidationAttribute
{
    /// <summary>
    ///     Maximum length of the enumerable.
    /// </summary>
    private readonly int _maxLength;

    /// <summary>
    ///     Minimum length of the enumerable.
    /// </summary>
    private readonly int _minLength;

    /// <inheritdoc />
    public EnumerableLengthAttribute(int minLength, int maxLength)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IEnumerable enumerable) return ValidationResult.Success;

        var count = enumerable.Cast<object?>().Count();

        if (count >= _minLength && count <= _maxLength)
            return ValidationResult.Success;
        return new ValidationResult($"The enumerable must have a length between {_minLength} and {_maxLength}.");
    }
}