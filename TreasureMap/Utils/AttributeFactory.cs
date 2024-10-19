using System.Reflection;
using TreasureMap.Attribute;

namespace TreasureMap.Utils;

/// <summary>
///     Factory class for creating an instance based on the model type
///     <remarks>
///         This system can cause performance issues due to the extensive use of reflection and type searching.
///     </remarks>
/// </summary>
public static class AttributeFactory
{
    /// <summary>
    ///     Get an instance of a class that implements ISingleton and has a specific attribute
    /// </summary>
    /// <param name="modelType">Find the attribute matching with this model type</param>
    /// <typeparam name="TResult"> The type of the instance to return </typeparam>
    /// <typeparam name="TAttribute">The type of the attribute to look for</typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    ///     If the instance type does not implement ISingleton or the GetInstance
    ///     method is not found
    /// </exception>
    public static TResult GetInstance<TResult, TAttribute>(Type modelType) where TAttribute : IoAttribute
    {
        var instanceType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .FirstOrDefault(type =>
                typeof(TResult).IsAssignableFrom(type) &&
                type.GetCustomAttribute<TAttribute>()?.ModelType == modelType);

        if (instanceType == null)
            throw new InvalidOperationException($"No instance found for model type {modelType.Name}");

        var instance = Activator.CreateInstance(instanceType);
        if (instance == null) throw new InvalidOperationException($"No instance found for model type {modelType.Name}");


        return (TResult) instance;
    }
}