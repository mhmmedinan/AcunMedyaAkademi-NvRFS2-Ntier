using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Concretes.EntityFramework.Contexts;
using System.Reflection;

namespace Repositories;

public static class RepositoriesServiceRegistration
{
    public static IServiceCollection AddRepositoriesServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("BaseDb")));

        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.ServiceType.Name.EndsWith("Repository"));
        return services;
    }

}
