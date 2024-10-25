using CocheraTp.Repository.CarpetaRepositoryVehiculo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.UnitofWorkVehiculo;
using CocheraTp.Servicios.VehiculoServicio;
using CocheraTp.Models;
using Microsoft.EntityFrameworkCore;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVehiculoServicio, VehiculoServicio>();
builder.Services.AddScoped<IUnitOfWorkVehiculo, UnitOfWorkVehiculo>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();

builder.Services.AddControllers();
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
