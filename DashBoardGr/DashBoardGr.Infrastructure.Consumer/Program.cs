using DashBoardGr.Infrastructure.Consumer;
using DashBoardGr.Infrastructure;

var builder = Host.CreateDefaultBuilder(args);
builder
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMessageBus();
    });



IHost host = builder.Build();
await host.RunAsync();
