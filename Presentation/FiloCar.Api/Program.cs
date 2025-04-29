using System;
using FiloCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using FiloCar.Application;
using FiloCar.Persistence;
using FiloCar.Mapper;
using FiloCar.Application.Exceptions;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Settings.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FiloCar API", Version = "v1" });

});


builder.Services.AddPersistence(builder.Configuration);

// Serilog yapýlandýrmasý
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.MSSqlServer(
       connectionString: builder.Configuration.GetConnectionString("SQLServer"),

        sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
        {
            TableName = "Logs", // Logs adýnda tablo olacak
            AutoCreateSqlTable = true // Yoksa tabloyu oluþturur
        })
    .CreateLogger();

builder.Services.AddApplication();
builder.Services.AddCustomMapper();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Host.UseSerilog();



// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
