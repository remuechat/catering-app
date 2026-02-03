using IMS.Domain.Models;
using IMS.Service.Interfaces;
using IMS.Service.Services;

// ABSOLUTELY DO NOT TOUCH THESE!
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IFoodService, FoodService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS API v1");
        options.RoutePrefix = "swagger"; 
    });
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();