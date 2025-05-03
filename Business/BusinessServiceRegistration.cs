using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.ServiceType.Name.EndsWith("Manager"));
        return services;
    }
}
