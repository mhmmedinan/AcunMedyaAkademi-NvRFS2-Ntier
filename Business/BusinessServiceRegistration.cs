using Core.Extensions;
using Core.Rules;
using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ITokenHelper,JwtHelper>();

        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.ServiceType.Name.EndsWith("Manager"));
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(),typeof(BaseBusinessRules));
        return services;
    }
}
