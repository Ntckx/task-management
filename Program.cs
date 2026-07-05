

using Microsoft.EntityFrameworkCore;
using TaskManagement.data;
using TaskManagement.Exceptions;
using TaskManagement.Factory;
using TaskManagement.Observer;
using TaskManagement.Repository;
using TaskManagement.Services;
using TaskManagement.State;
using TaskManagement.Strategy;

// Registers Service, Config, Logging, Controller, Database
var builder = WebApplication.CreateBuilder(args);

// Use controller based api endpoints
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskFactoryRegistry, TaskFactoryRegistry>();
builder.Services.AddScoped<IPriorityStrategyRegistry, PriorityStrategyRegistry>();
builder.Services.AddScoped<TaskStateRestorer>();
builder.Services.AddScoped<List<ITaskObserver>>(provider => new List<ITaskObserver>
{
    new EmailObserver(),
    new LogObserver()
});
builder.Services.AddScoped<BugPriority>();
builder.Services.AddScoped<FeaturePriority>();
builder.Services.AddScoped<StoryPriority>();

builder.Services.AddScoped<BugFactory>();
builder.Services.AddScoped<FeatureFactory>();
builder.Services.AddScoped<StoryFactory>();

// Registers AppDbContext to Dependency Injection Container
// AppDbContext can be injected to Controllers, Services
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
