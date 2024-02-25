using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TaskManagement;
using TaskManagement.Services;

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
builder.Services.AddTransient<IAuthService, AuthService>();

//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(1800);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie(options =>
//        {
//            options.Cookie.Name = "auth";
//            options.Cookie.HttpOnly = true;
//            options.LoginPath = new PathString("/auth/login");
//            options.LogoutPath = new PathString("/auth/logout");
//            options.AccessDeniedPath = new PathString("/tasks");
//            options.ExpireTimeSpan = TimeSpan.FromDays(1);
//            options.SlidingExpiration = false;
//        });

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

//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
