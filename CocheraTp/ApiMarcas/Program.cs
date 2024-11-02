using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryMarca.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryMarca.UnitOfWorkMarca;
using CocheraTp.Servicios.MarcaServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IUnitOfWorkMarca, UnitOfWorkMarca>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

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
