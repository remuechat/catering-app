using IMS.Domain.Models;
using IMS.Service.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Use InMemory with name from config (or direct name)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("IMS.TestDB") // Simple, clean approach
);

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS API v1");
        options.RoutePrefix = "swagger";
    });
    app.MapOpenApi();
}

// Initialize InMemory database (NO migrations!)
// Migrate later on IF YOU HAVE AN ACTUAL DB!
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
    Console.WriteLine("In-memory database created successfully");
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
