using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;

public static class AssemblyTypeRegistration
{
    public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services,Assembly assembly)
    {
        var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
        foreach (Type? type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface,type);
            }
        }
        return services;
    }
}
