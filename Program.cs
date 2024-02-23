using Microsoft.EntityFrameworkCore;
using TaskManagement;
using TaskManagement.Services;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

/* Database Context Dependency Injection */
string dbConnection = configuration["ConnectionStrings:dbConnection"];
builder.Services.AddDbContext<TaskDbContext>(opt => opt.UseSqlServer(dbConnection));
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendUI");
app.UseAuthorization();

app.MapControllers();
app.Run();
