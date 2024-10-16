namespace TreasureMap.Utils;

/// <summary>
/// Interface for the singleton.
/// </summary>
public interface ISingleton
{
    /// <summary>
    ///  Get the instance of the singleton.
    /// </summary>
    /// <returns></returns>
    static abstract ISingleton GetInstance();
}