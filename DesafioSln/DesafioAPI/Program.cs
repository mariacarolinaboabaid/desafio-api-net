using System.Reflection;
using DesafioAPI.Context;
using DesafioAPI.Respositories;
using DesafioAPI.Respositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adição do serviço Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Adição do serviço Fluent Validation
builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
);

// Adição do escopo e implementação das interfaces dos repositórios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRealStateRepository, RealStateRepository>();
builder.Services.AddScoped<IRealStateImageRepository, RealStateImageRepository>();

// Adição do serviço Cors
builder.Services.AddCors();

// Connection string do banco de dados
string connectionString = "Data Source=/Users/mariacarolinaboabaid/Downloads/api-net/database.db;";
builder.Services.AddDbContext<EstateAgencyContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
