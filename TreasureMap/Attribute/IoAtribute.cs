namespace TreasureMap.Attribute;

/// <summary>
/// Attribute to mark the class that will parse the data.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class IoAttribute : System.Attribute
{
    /// <summary>
    ///  Type of the class to be parsed.
    /// </summary>
    public Type ModelType { get; }

    /// <inheritdoc />
    public IoAttribute(Type modelType)
    {
        ModelType = modelType;
    }

}