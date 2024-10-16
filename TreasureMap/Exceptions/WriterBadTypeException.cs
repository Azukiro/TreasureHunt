namespace TreasureMap.Exceptions;

/// <summary>
///  Exception thrown when a writer does not support a type.
/// </summary>
/// <typeparam name="T">Type manipulate by the writer</typeparam>
public class WriterBadTypeException<T> : Exception
{
    /// <summary>
    ///  Constructor
    /// </summary>
    /// <param name="errorType">Type of the object send to the writer</param>
    public WriterBadTypeException(Type errorType) : base($"Writer {typeof(T).Name} does not support type {errorType.Name}")
    {
    }
}