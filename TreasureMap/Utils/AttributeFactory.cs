using System.Reflection;
using TreasureMap.Attribute;

namespace TreasureMap.Utils;

/// <summary>
/// Factory class for creating an instance based on the model type
/// <remarks>
/// This system can cause performance issues due to the extensive use of reflection and type searching.
/// </remarks> 
/// </summary>
public static class AttributeFactory
{
    /// <summary>
    /// Get an instance of a class that implements ISingleton and has a specific attribute
    /// </summary>
    /// <param name="modelType">Find the attribute matching with this model type</param>
    /// <typeparam name="TAttribute">The type of the attribute to look for</typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"> If the instance type does not implement ISingleton or the GetInstance method is not found</exception>
    public static ISingleton GetInstance<TAttribute>(Type modelType)where TAttribute : IoAttribute
    {
        var instanceType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .FirstOrDefault(type => 
                typeof(ISingleton).IsAssignableFrom(type) && 
                type.GetCustomAttribute<TAttribute>()?.ModelType == modelType);
        
        if (instanceType == null)
        {
            throw new InvalidOperationException($"No instance found for model type {modelType.Name}");
        }

        MethodInfo? getInstanceMethod = instanceType.GetMethod("GetInstance", BindingFlags.Static | BindingFlags.Public);
        if (getInstanceMethod == null)
        {
            throw new InvalidOperationException($"GetInstance method not found on instance type {instanceType.Name}");
        }

        object? instance = getInstanceMethod.Invoke(null, null);
        if (instance == null)
        {
            throw new InvalidOperationException($"Failed to retrieve the singleton instance of {instanceType.Name}");
        }

        return (ISingleton)instance;
    }
}