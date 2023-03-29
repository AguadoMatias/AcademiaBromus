global using AcademiaBromus.Models;
using AcademiaBromus.DAOs;
using AcademiaBromus.Services.CustomerService;
using AcademiaBromus.Services.ShipperService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDAO, CustomerDao>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
