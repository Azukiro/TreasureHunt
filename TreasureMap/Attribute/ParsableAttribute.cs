namespace TreasureMap.Attribute;

/// <summary>
///     Attribute to mark the class that will parse the data.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ParsableAttribute : IoAttribute
{
    /// <inheritdoc />
    public ParsableAttribute(Type modelType) : base(modelType)
    {
    }
}