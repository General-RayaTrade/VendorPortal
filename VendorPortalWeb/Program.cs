using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;
using VendorPortal.EF;
using VendorPortal.EF.Infrastructure;
using VendorPortal.EF.IRepositories;
using VendorPortal.EF.Repositories;
using VendorPortal.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Scoped);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IConfirmationService, ConfirmationService>();
builder.Services.AddTransient<ICitiesDistrictsService, CitiesDistrictsService>();
builder.Services.AddTransient<IMoblieNumberValidationService, MoblieNumberValidationService>();
builder.Services.AddTransient<ISupplyChainGatewayService, SupplyChainGatewayService>();
builder.Services.AddTransient<IDynamicsService, DynamicsService>();
builder.Services.AddTransient<IB2CService, B2CService>();
builder.Services.AddTransient<IOrderTrackingService, OrderTrackingService>();
//builder.Services.AddTransient<INotificationService, NotificationService>();

builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IRealTimeNotification, SignalRNotification>();

builder.Services.AddSignalR();
//builder.Services.AddTransient<ISupplyChainGatewayService, SupplyChainGatewayService>();
builder.Services.AddHttpClient();

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

// Configure SignalR endpoint
app.MapHub<NotificationHub>("/notificationHub");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
