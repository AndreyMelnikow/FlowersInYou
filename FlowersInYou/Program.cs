using FlowersInYou;
using FlowersInYou.Repositories;
using FlowersInYou.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FlowersInYouContext>();
builder.Services.AddTransient<IBusketOrderRepository, BusketOrderRepository>();
builder.Services.AddTransient<IBusketRepository, BusketRepository>();
builder.Services.AddTransient<IBusketService, BusketService>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IConfigurateProductRepository, ConfigurateProductRepository>();
builder.Services.AddTransient<IConfigurateProductService, ConfigurateProductService>();
builder.Services.AddTransient<IConfirmedOrderRepository, ConfirmedOrderRepository>();
builder.Services.AddTransient<IConfirmedOrderService, ConfirmedOrderService>();
builder.Services.AddTransient<ICourierRepository, CourierRepository>();
builder.Services.AddTransient<ICourierService, CourierService>();
builder.Services.AddTransient<IFloristRepository, FloristRepository>();
builder.Services.AddTransient<IFloristService, FloristService>();
builder.Services.AddTransient<IMaterialRepository, MaterialRepository>();
builder.Services.AddTransient<IMaterialService, MaterialService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ISizeRepository, SizeRepository>();
builder.Services.AddTransient<ISizeService, SizeService>();
builder.Services.AddTransient<IZoneRepository, ZoneRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
