using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.UnitOfWorkDetalleFactura;
using CocheraTp.Repository.CarpetaRepositoryFactura.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura;
using CocheraTp.Servicios.DetalleFacturaServicio;
using CocheraTp.Servicios.FacturaServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IUnitOfWorkFactura, UnitOfWorkFactura>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();
builder.Services.AddScoped<IUnitOfWorkDetalleFactura, UnitOfWorkDetalleFactura>();
builder.Services.AddScoped<IDetalleFacturaServicio, DetalleFacturaServicio>();

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
