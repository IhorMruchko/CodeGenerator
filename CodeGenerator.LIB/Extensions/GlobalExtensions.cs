using System;
using System.Linq;

namespace CodeGenerator.LIB.Extensions;

public static class GlobalExtensions
{
    public static TObject Copy<TObject>(this TObject souce)
    {
        var copy = Activator.CreateInstance<TObject>();
        
        foreach (var propety in typeof(TObject).GetProperties().Where(info => info.CanRead && info.CanWrite))
            propety.SetValue(copy, propety.GetValue(souce));
        
        return copy;
    }

    public static TTarget CopyFrom<TTarget, TSource>(this TTarget target, TSource source)
    {
        var properties = typeof(TTarget).GetProperties()
            .Select(property => property.Name)
            .Intersect(typeof(TSource).GetProperties()
            .Where(info => info.CanRead)
            .Select(property => property.Name))
            .ToArray();
        
        foreach (var prop in properties)
        {
            var targetProperty = typeof(TTarget).GetProperty(prop);
            var sourceProperty = typeof(TSource).GetProperty(prop);

            if (targetProperty == null || sourceProperty == null) continue;
            if (targetProperty.PropertyType != sourceProperty.PropertyType) continue;

            targetProperty.SetValue(target, sourceProperty.GetValue(source));
        }

        return target;
    }
}
