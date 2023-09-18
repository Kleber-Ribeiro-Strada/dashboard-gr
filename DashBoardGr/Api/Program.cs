using DashBoardGr.Domain.Application;
using DashBoardGr.Infrastructure;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Strada.Template.Api.Configurations.Observability;
using DashBoardGr.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatRs();
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
//app.UseMiddleware<GlobalErrorHandlingMiddleware>();
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

app.Run();
