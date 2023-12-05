using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BTL_LWNC_WebAmNhac.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BTL_LWNC_WebAmNhacContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("BTL_LWNC_WebAmNhacContext") ?? throw new InvalidOperationException("Connection string 'BTL_LWNC_WebAmNhacContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(option =>
	{
		option.LoginPath = "/Users/Login";
		option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
