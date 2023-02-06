using BestPractice.Api.Extensions;
using BestPractice.Api.Logging;
using BestPractice.Api.Models;
using BestPractice.Api.Service;
using BestPractice.Api.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddControllers()
        .AddFluentValidation(i => i.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddScoped<IContactService , ContactService>();

builder.Services.ConfigureMapping();

builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddHttpClient("garantiapi", config =>
{
    config.BaseAddress = new Uri("http://www.garanti.com");
    config.DefaultRequestHeaders.Add("Authorization", "Bearer 123123");
});

builder.Services.AddLogging();

Logger log = new LoggerConfiguration()
    .WriteTo.Debug((Serilog.Events.LogEventLevel)LogLevel.Information)
    .CreateLogger();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomHealthCheck();
app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
