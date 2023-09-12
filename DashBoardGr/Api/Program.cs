using DashBoardGr.Domain.Application;
using DashBoardGr.Domain.Application.Commands.SolicitarAnalise;
using DashBoardGr.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Strada.Template.Api.Configurations.Observability;
using System.Reflection;
using DashBoardGr.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatRs();
builder.Services.AddRepositoryContext(builder.Configuration);


builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddHeaderPropagation(s => { s.Headers.Add("x-correlation-id"); });
builder.Services.ConfigureSerilog();
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddFluentValidations();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessageBus();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.UseHttpLogging();
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

app.Run();
