using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using WEBAPI.Filters;
using Repository.Models;
using WEBAPI.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ClienteRequest>, ClienteValidation>();
builder.Services.AddScoped<IValidator<FacturaRequest>, FacturaValidation>();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<FiltroValidacion>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("postgresDB");
builder.Services.AddDbContext<ContextoAplicacionDB>(options =>
{
    options.UseNpgsql(connectionString);
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

app.Run();
