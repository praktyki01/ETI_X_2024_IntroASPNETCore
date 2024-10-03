using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ETI_X_2024_IntroASPNETCore.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ETI_X_2024_IntroASPNETCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ETI_X_2024_IntroASPNETCoreContext") ?? throw new InvalidOperationException("Connection string 'ETI_X_2024_IntroASPNETCoreContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
