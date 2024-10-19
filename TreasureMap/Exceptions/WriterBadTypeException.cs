namespace TreasureMap.Exceptions;

/// <summary>
///     Exception thrown when a writer does not support a type.
/// </summary>
/// <typeparam name="T">Type manipulate by the writer</typeparam>
/// <param name="errorType">Type that the writer does not support</param>
public class WriterBadTypeException<T>(Type errorType) : Exception(
    $"Writer {typeof(T).Name} does not support type {errorType.Name}");