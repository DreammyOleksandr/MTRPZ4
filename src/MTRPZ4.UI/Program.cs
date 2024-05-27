using MTRPZ4.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MTRPZ4.Infrastructure.Repository.IRepository;
using MTRPZ4.Infrastructure.Repository;
using MTRPZ4.Infrastructure.DataStorage;
using Microsoft.AspNetCore.Builder;
using MTRPZ4.Infrastructure.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDBConnection();
builder.Services.ConfigurateIdentityOptions();
builder.Services.AddIdentityUser();

builder.Services.AddControllersWithViews();

//remove latter
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

builder.Services.AddScoped<IButtonColorRepository, ButtonColorRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<IDataStorage, DataStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//remove latter
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // ўоб мати доступ до Swagger UI на кореневому URL
});

await app.SeedStartupDb();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

//remove comment latter
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.Run();
