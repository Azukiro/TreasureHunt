namespace TreasureMap.Exceptions;

public class BoundingMapNotSetException : Exception
{
    public BoundingMapNotSetException() : base("The map must be set before adding any other element.")
    {
    }
}