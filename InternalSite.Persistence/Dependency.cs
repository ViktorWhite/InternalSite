using InternalSite.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternalSite.Persistence
{
    /// <summary>
    /// Статический класс Dependency Injection
    /// </summary>
    public static class Dependency
    {
        /// <summary>
        /// Статический метод, для вложения в DI контейнер сервиса, который дает доступ к базе данных через строку подключения к бд
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection PersistenceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            return services
            .AddDbContext<InternalSiteDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]))
            .AddScoped<IInternalSiteDbContext> (provider =>
            provider.GetService<InternalSiteDbContext>() ?? throw new Exception("Failed to resolve InternalSiteDbContext."));
        }
    }
}
