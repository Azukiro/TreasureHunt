namespace TreasureMap.Attribute;

/// <summary>
///     Attribute to mark the class that will write the data.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class WritableAttribute : IoAttribute
{
    /// <inheritdoc />
    public WritableAttribute(Type modelType) : base(modelType)
    {
    }
}