using CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar;
using CocheraTp.Servicios.LugarServicio;
using CocheraTp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<db_cocherasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILugarRepository, LugarRepository>();
builder.Services.AddScoped<IUnitOfWorkLugar, UnitOfWorkLugar>();
builder.Services.AddScoped<ILugarService, LugarService>();

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
