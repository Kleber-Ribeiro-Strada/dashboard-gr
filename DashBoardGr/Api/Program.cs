using DashBoardGr.Domain.Application;
using DashBoardGr.Infrastructure;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Strada.Template.Api.Configurations.Observability;
using DashBoardGr.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Api.Configuration;
using System.Net;
using System.Text;
using System.Net.WebSockets;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatRs();
builder.Services.AddExternalServices();
builder.Services.AddRepositoryContext(builder.Configuration);

builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddHeaderPropagation(s => { s.Headers.Add("x-correlation-id"); });
builder.Services.ConfigureSerilog();
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", b =>
{
    b.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddFluentValidations();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessageBus();
builder.Services.AddMappers();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields =
      HttpLoggingFields.RequestPropertiesAndHeaders
    | HttpLoggingFields.RequestBody
    | HttpLoggingFields.RequestQuery
    | HttpLoggingFields.RequestMethod
    | HttpLoggingFields.RequestProtocol
    | HttpLoggingFields.RequestPath;

    logging.RequestHeaders.Add("x-correlation-id");
    logging.RequestHeaders.Add("Authorization");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Cors
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.UseHttpLogging();
app.UseMiddleware<TraceMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.UseHealthCheck();
});

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = "/wwwroot"
});

app.UseWebSockets();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/websocket")
    {
        if (!context.WebSockets.IsWebSocketRequest)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        }
        else
        {

            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

            while (true)
            {
                var mensagem = new Dictionary<string, string>
                {
                    { "data", $"{DateTime.UtcNow}"},
                    { "key2", "value2" }
                };
                var data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(mensagem));

                await webSocket.SendAsync(data, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);

                await Task.Delay(10000);
            }

        }
    }
    else
    {
        await next();
    }

});

app.Map("/websocket", async context =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

    }
    else
    {
        while (true)
        {
            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            var data = Encoding.UTF8.GetBytes($".net rocks => {DateTime.Now}");

            await webSocket.SendAsync(data, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);

            await Task.Delay(1000);
        }
    }


});

await app.RunAsync();
