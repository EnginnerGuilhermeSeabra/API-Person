using Person.Application.Validators;

namespace Person.API.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<ICreatePersonCommandValidator, CreatePersonCommandValidator>();
            services.AddScoped<IUpdatePersonCommandValidator, UpdatePersonCommandValidator>();
            return services;
        }
    }
}
