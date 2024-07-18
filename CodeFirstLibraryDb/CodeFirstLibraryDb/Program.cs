using CodeFirstLibraryDb.Context;
using CodeFirstLibraryDb.Repositories.Implementaciones;
using CodeFirstLibraryDb.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//(1) Inyección de dependencias
builder.Services.AddScoped<IAutoresRepository, AutoresRepository>();
builder.Services.AddScoped<IGenerosRepository, GenerosRepository>();
builder.Services.AddScoped<ILibrosRepository, LibrosRepository>();

//2) Base de datos (Normal)
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//3) Automapper (Para mapear los DTOs)
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//4) Fluent Validation
builder.Services.AddFluentValidation((options) =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//5) Cors
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
