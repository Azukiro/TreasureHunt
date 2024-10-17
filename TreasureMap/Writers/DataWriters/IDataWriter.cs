using TreasureMap.Utils;

namespace TreasureMap.Writers.DataWriters;

/// <summary>
/// Interface for the data writer.
/// </summary>
public interface IDataWriter
{
    /// <summary>
    /// Write the object to a string.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    string Write(object obj);
}