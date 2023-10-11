using InventoryManagement_2.Data;
using InventoryManagement_2.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using InventoryManagement_2.Manager.Interfaces;
using InventoryManagement_2.Provider.Interface;
using InventoryManagement_2.Provider;
using AspNetCoreHero.ToastNotification;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//new
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x => { x.LoginPath = "/Auth/Login"; });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//new
builder.Services.AddControllers();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<DbContext, ApplicationDbContext>();
builder.Services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;config.Position = NotyfPosition.BottomRight; });


var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>()?.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapRazorPages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

app.Run();
