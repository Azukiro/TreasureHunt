using NLog;

namespace TreasureMap.Utils;

/// <summary>
///     Helper class for logging. Is configure for logging to the console and in file.
/// </summary>
public static class LoggerHelper
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    ///     Logs a warning message.
    /// </summary>
    /// <param name="message"></param>
    public static void LogWarn(string message)
    {
        Logger.Warn(message);
    }

    /// <summary>
    ///     Logs an error message.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="message"></param>
    public static void LogError(Exception e, string message)
    {
        Logger.Error(e, message);
    }

    /// <summary>
    ///     Logs an error message.
    /// </summary>
    /// <param name="message"></param>
    public static void LogError(string message)
    {
        Logger.Error(message);
    }

    /// <summary>
    ///     Logs an info message.
    /// </summary>
    /// <param name="message"></param>
    public static void LogInfo(string message)
    {
        Logger.Info(message);
    }
}