global using AcademiaBromus.Models;
using AcademiaBromus.DAOs;
using AcademiaBromus.Services.CustomerService;
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
        options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind"));
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});



// Define la implementacion que se debe tomar para las Interfaces 
builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<IShipperDAO, ShipperDAO>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDAO, CustomerDao>();


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
