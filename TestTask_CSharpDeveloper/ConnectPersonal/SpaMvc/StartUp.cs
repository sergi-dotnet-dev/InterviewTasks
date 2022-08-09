using Microsoft.EntityFrameworkCore;
using SpaMvc.DAL;
using SpaMvc.Infrastructure;
using SpaMvc.Infrastructure.Abstract;
using SpaMvc.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services
    .AddScoped<IDataRepository<Product>, ProductDataRepository>();
builder.Services
    .AddScoped<IDataRepository<Category>, CategoryDataRepository>();
builder.Services
    .AddTransient<IServerConnect>(x => ActivatorUtilities.CreateInstance<SqlConnect>(x, builder.Configuration.GetConnectionString("Default")));
builder.Services
    .AddControllersWithViews(option => option.RespectBrowserAcceptHeader = true);
builder.Services
    .AddResponseCompression(options => options.EnableForHttps = true);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Product}/{action=GetProducts}/{category?}");
app.Run();