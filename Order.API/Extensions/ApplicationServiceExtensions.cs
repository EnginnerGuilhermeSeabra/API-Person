using Person.Application.Services;
using Person.Application.Services.Interfaces;
using Person.Domain.Aggregates.PersonAggregate.Interface;
using Person.Infra.Data;
using Person.Infra.Data.Repositories;

namespace Person.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
