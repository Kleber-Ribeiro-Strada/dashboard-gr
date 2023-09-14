using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Application.Profiles;

namespace DashBoardGr.Domain.Application
{
    public static class ApplicationModule
    {

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MotoristaProfile));
            return services;
        }

        public static IServiceCollection AddMediatRs(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(SolicitarAnaliseCommandHandler).Assembly);
            });

            return services;
        }

        public static IServiceCollection AddFluentValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<SolicitarAnaliseCommandValidator>();

            return services;
        }
    }
}
