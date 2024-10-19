namespace TreasureMap.Exceptions;

/// <summary>
///     Exception thrown when an error occurs while parsing a line.
/// </summary>
/// <param name="line"></param>
/// <param name="innerException"></param>
public class ParsingException(string[] lineData, Exception innerException)
    : Exception($"Error parsing line: {string.Join(" ", lineData)}", innerException);