using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Database.Data;
using MVC_Identity.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MVC_DbContext>(options =>
    options
    .UseSqlServer(builder.Configuration
    .GetConnectionString("MVC_DatabaseContext") ?? throw new InvalidOperationException("Connection string 'MVC_DatabaseContext' not found.")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MVC_DbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});



var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });
app.Run();
