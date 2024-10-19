namespace TreasureMap.Utils;

/// <summary>
///     Helper class to validate objects.
/// </summary>
public class SimpleServiceProvider(Dictionary<Type, object> services) : IServiceProvider
{
    /// <summary>
    ///     Gets the service object of the specified type.
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    public object? GetService(Type serviceType)
    {
        services.TryGetValue(serviceType, out var service);
        return service;
    }
}