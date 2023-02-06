using BestPractice.Api.Extensions;
using BestPractice.Api.Models;
using BestPractice.Api.Service;
using BestPractice.Api.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomHealthCheck();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
