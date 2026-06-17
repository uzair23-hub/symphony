using Microsoft.EntityFrameworkCore;
using SymphonyLtdMVC1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SymphonyLtdDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromHours(8); options.Cookie.HttpOnly = true; });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
