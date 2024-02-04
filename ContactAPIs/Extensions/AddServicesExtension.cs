using ContactAPIs.Bll.Services;
using ContactAPIs.Core.Repositories;
using ContactAPIs.Core.Services;
using ContactAPIs.Dal.Repositories;

namespace ContactAPIs.Extensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<IContactsService, ContactsService>();

            return services;
        }
    }
}
