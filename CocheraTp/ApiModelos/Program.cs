using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryModelo.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryModelo.UnitOfWorkModelo;
using CocheraTp.Servicios.ModeloServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
builder.Services.AddScoped<IUnitOfWorkModelo, UnitOfWorkModelo>();
builder.Services.AddScoped<IModeloService, ModeloService>();

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
