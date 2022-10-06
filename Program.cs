using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// using FloorForce2.Data;
using FloorForce2.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MvcFloorContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MvcFloorContext")));
}
else
{
    builder.Services.AddDbContext<MvcFloorContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcFloorContext")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddDbContext<MvcFloorContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcFloorContext") ?? throw new InvalidOperationException("Connection string 'MvcFloorContext' not found.")));
    
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
