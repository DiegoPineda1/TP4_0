using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Implementacion;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.UnitOfWorkTipoFac;
using CocheraTp.Servicios.TipoFacServicio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITipoFacRepository, TipoFacRepository>();
builder.Services.AddScoped<IUnitOfWorkTipoFac, UnitOfWorkTipoFac>();
builder.Services.AddScoped<ITipoFacService, TipoFacService>();



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
