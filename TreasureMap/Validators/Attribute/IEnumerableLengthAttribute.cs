using System.ComponentModel.DataAnnotations;

namespace TreasureMap.Validators.Attribute;

/// <summary>
///  Attribute to validate the length of an enumerable.
/// </summary>
public class EnumerableLengthAttribute : ValidationAttribute
{
    /// <summary>
    /// Minimum length of the enumerable.
    /// </summary>
    private readonly int _minLength;

    /// <summary>
    /// Maximum length of the enumerable.
    /// </summary>
    private readonly int _maxLength;

    /// <inheritdoc />
    public EnumerableLengthAttribute(int minLength, int maxLength)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }
    
    public override bool IsValid(object? value)
    {
        if (value is not System.Collections.IEnumerable enumerable)
        {
            return false;
        }
        
        var count = enumerable.Cast<object?>().Count();

        return count >= _minLength && count <= _maxLength;
    }
    
}