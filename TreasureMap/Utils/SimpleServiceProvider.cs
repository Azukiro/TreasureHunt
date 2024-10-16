namespace TreasureMap.Utils;

/// <summary>
/// Helper class to validate objects.
/// </summary>
public class SimpleServiceProvider(Dictionary<Type, object> services) : IServiceProvider
{
    public object? GetService(Type serviceType)
    {
        services.TryGetValue(serviceType, out var service);
        return service;
    }
}