namespace TreasureMap.Exceptions;

/// <summary>
///     Exception thrown when the map bounding box is not set.
/// </summary>
public class BoundingMapNotSetException() : Exception("The map must be set before adding any other element.");