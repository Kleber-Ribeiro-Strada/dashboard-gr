using DashBoardGr.Infrastructure.Consumer;
using DashBoardGr.Infrastructure;
using DashBoardGr.Infrastructure.Consumer.Recivers;
using DashBoardGr.Domain.Application;
using DashBoardGr.Domain.Repository;

var builder = Host.CreateDefaultBuilder(args);
builder
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        services.AddHostedService<Worker>();
        services.AddHostedService<SolicitarAnaliseConsumer>();
        services.AddMessageBus();
        services.AddMediatRs();
        services.AddMappers();
        services.AddFluentValidations();
        services.AddRepositoryContext(configuration);
    });



IHost host = builder.Build();
await host.RunAsync();
