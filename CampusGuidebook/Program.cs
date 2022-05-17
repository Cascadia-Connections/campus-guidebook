using CampusGuidebook.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//Branch 13 & 14 have a table for event rejection response and reasoning and branch 19 has the log-in/logout/register

var builder = WebApplication.CreateBuilder(args);

// Add Databases Services to Container.
var DefaultConnectionString = builder.Configuration.GetConnectionString("AppDefault-SqlServer");
var IdentityConnectionString = builder.Configuration.GetConnectionString("AppIdentity-SqlServer");

//Enable for use of Sqlite on Mac
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(DefaultConnectionString));
//builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite(IdentityConnectionString));

//Enable for use of SqlServer on Windows
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DefaultConnectionString));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(IdentityConnectionString));

// Add Developer, Identity and Controller Services
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AppDbContext>();

//DIJ for AppDbContext
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();

