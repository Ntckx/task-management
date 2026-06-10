

using Microsoft.EntityFrameworkCore;
using TaskManagement.data;
using TaskManagement.Factory;

// Registers Service, Config, Logging, Controller, Database
var builder = WebApplication.CreateBuilder(args);

// Use controller based api endpoints
builder.Services.AddControllers();
builder.Services.AddScoped<BugFactory>();
builder.Services.AddScoped<FeatureFactory>();
builder.Services.AddScoped<StoryFactory>();

// Registers AppDbContext to Dependency Injection Container
// AppDbContext can be injected to Controllers, Services
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
