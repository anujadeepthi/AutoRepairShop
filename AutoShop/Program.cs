using Microsoft.EntityFrameworkCore;
using AutoShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AutoRepairDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
