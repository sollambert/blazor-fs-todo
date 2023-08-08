using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<TodoItemService>();

DotNetEnv.Env.Load();

string DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
// Console.WriteLine($"Using connection string: {DATABASE_URL}");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(DATABASE_URL)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
