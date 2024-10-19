namespace TreasureMap.Attribute;

/// <summary>
///     Attribute to mark the class that will be manipulated for IO operations.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class IoAttribute : System.Attribute
{
    /// <summary>
    ///     Initializes a new instance of the Attribute.
    ///     <param name="modelType"> Type of the class to be manipulated. </param>
    /// </summary>
    public IoAttribute(Type modelType)
    {
        ModelType = modelType;
    }

    /// <summary>
    ///     Type of the class to be manipulated.
    /// </summary>
    public Type ModelType { get; }
}