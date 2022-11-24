using Microsoft.EntityFrameworkCore;
using MVC_Database.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MVC_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_DatabaseContext") ?? throw new InvalidOperationException("Connection string 'MVC_DatabaseContext' not found.")));

builder.Services.AddMvc();

var app = builder.Build(); 



app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });
app.Run();
