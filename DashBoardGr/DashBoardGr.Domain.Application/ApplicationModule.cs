using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Domain.Application.Profiles;
using DashBoardGr.Domain.Application.Commands.AvaliarAnalise;
using DashBoardGr.Domain.Application.Queries.AnaliseQueries.BuscarAnalise;

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
                cfg.RegisterServicesFromAssemblies(typeof(AvaliarAnaliseCommandHandler).Assembly);
                cfg.RegisterServicesFromAssemblies(typeof(BuscarAnaliseQueryHandler).Assembly);
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
