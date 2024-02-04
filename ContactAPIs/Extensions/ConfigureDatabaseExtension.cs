using ContactAPIs.Dal;
using Microsoft.EntityFrameworkCore;

namespace ContactAPIs.Extensions
{
    public static class ConfigureDatabaseExtension
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ContactsDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("dbconn")),
                contextLifetime: ServiceLifetime.Transient);

            return services;
        }
    }
}
