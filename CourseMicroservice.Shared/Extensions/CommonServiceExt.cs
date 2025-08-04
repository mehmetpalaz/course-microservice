using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CourseMicroservice.Shared.Extensions
{
    public static class CommonServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(assembly));

            services.AddValidatorsFromAssemblyContaining(assembly);

            services.AddAutoMapper((c) => { }, assembly);

            return services;
        }
    }
}
