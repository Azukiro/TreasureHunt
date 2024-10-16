namespace TreasureMap.Exceptions;

/// <summary>
/// Exception thrown when moving to a restricted cell.
/// </summary>
public class RestrictedCellException : Exception
{
    /// <inheritdoc />
    public RestrictedCellException(string message) : base(message)
    {
    }
}