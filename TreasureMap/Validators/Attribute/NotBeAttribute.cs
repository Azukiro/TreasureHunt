using System.ComponentModel.DataAnnotations;

namespace TreasureMap.Validators.Attribute;

/// <summary>
///     Attribute to validate that a value is not equal to a specified value.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class NotBeAttribute : ValidationAttribute
{
    private readonly object _forbiddenValue;

    public NotBeAttribute(object forbiddenValue)
    {
        // Ensure the value is an enum
        if (forbiddenValue == null || !forbiddenValue.GetType().IsEnum)
            throw new ArgumentException("The specified value must be an enumeration value.");

        _forbiddenValue = forbiddenValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null && value.Equals(_forbiddenValue))
            return new ValidationResult($"The value cannot be {_forbiddenValue}.");

        return ValidationResult.Success;
    }
}