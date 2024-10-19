namespace TreasureMap.Utils;

/// <summary>
///     Helper class for file operations.
/// </summary>
public static class FileHelper
{
    /// <summary>
    ///     Read the content of a file.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string Read(string path)
    {
        return File.ReadAllText(path);
    }

    /// <summary>
    ///     Write content to a file.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    public static void Write(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}