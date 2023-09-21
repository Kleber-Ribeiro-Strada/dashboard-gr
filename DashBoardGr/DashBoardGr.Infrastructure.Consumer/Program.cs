using DashBoardGr.Infrastructure.Consumer;
using DashBoardGr.Infrastructure;
using DashBoardGr.Infrastructure.Consumer.Recivers;

var builder = Host.CreateDefaultBuilder(args);
builder
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHostedService<SolicitarAnaliseConsumer>();
        services.AddMessageBus();
    });



IHost host = builder.Build();
await host.RunAsync();
