global using AcademiaBromus.Models;
using AcademiaBromus.DAOs;
using AcademiaBromus.Services.ShipperService;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AcademiaBromus.Data.NorthwindContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDB"));
    });


// Define la implementacion que se debe tomar para las Interfaces 
builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<IShipperDAO, ShipperDAO>();

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
