using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Posterr.Application;
using Posterr.Application.DTOs;
using Posterr.Application.Interfaces;
using Posterr.Application.Validations;
using Posterr.Domain.Interfaces;
using Posterr.Repository.Postgresql;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");

if (File.Exists(envFilePath))
{
    DotNetEnv.Env.Load(envFilePath);
}

var configuration = builder.Configuration.AddEnvironmentVariables().Build();

builder.Services.AddDbContext<PosterrDbContext>(options =>
           options.UseNpgsql(configuration.GetSection("ConnectionStrings:dbConnection").Value));

builder.Services.AddAutoMapper(typeof(UserDto).Assembly);

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                })
                .AddFluentValidation(fv => {
                    fv.DisableDataAnnotationsValidation = true;
                    fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>(lifetime: ServiceLifetime.Singleton);
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
