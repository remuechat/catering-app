using IMS.Domain.Models;

// ABSOLUTELY DO NOT TOUCH THESE!
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseHttpsRedirection();


// YES! You can edit these if you'd like!
var _foods = new List<Food>();

app.MapPost("/foods", (Food food) =>
{
    _foods.Add(food);
});

app.MapGet("/foods", () => {
    return _foods;
});

app.MapGet("/", () =>
{
    return "<h1>Hi</h1>";
});

app.Run();