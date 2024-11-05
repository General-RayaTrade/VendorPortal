using Microsoft.EntityFrameworkCore;
using VendorPortal.Core.IServices;
using VendorPortal.EF;
using VendorPortal.EF.IRepositories;
using VendorPortal.EF.Repositories;
using VendorPortal.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Scoped);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderService, OrderService>();
//builder.Services.AddTransient<IUnitOfWork, IUnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
