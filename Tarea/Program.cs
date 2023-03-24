global using Tarea.Models;
using Microsoft.EntityFrameworkCore;
using Tarea.DAOs;
using Tarea.Services.SupplierService;
using Tarea.Services.ShipperService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Tarea.Data.NorthwindContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"));
    });

// Define la implementacion que se debe tomar para las Interfaces 
builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<IShipperDAO, ShipperDAO>();


//ACA SE VINCULAN LO QUE SE VA A USAR LOS SERVICE Y DAO QUE SE VAN A USAR
// Suppliers
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierDAO, SupplierDAO>();

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
