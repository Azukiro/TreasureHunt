namespace TreasureMap.Attribute;

/// <summary>
///     Attribute to mark the class that will parse the data.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class IoAttribute : System.Attribute
{
    /// <inheritdoc />
    public IoAttribute(Type modelType)
    {
        ModelType = modelType;
    }

    /// <summary>
    ///     Type of the class to be parsed.
    /// </summary>
    public Type ModelType { get; }
}