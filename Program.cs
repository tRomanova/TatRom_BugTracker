using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TatRom_BugTracker.Data;
using TatRom_BugTracker.Extensions;
using TatRom_BugTracker.Models;
using TatRom_BugTracker.Services;
using TatRom_BugTracker.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<BTUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddClaimsPrincipalFactory<BTUserClaimsPrincipalFactory>()//will store 
    .AddDefaultUI()
    .AddDefaultTokenProviders();

//builder.Services.AddControllersWithViews();

//My Custom Services
builder.Services.AddScoped<IBTFileService, BTFileService>();
builder.Services.AddScoped<IBTUserService, BTUserService>();
builder.Services.AddScoped<IBTTicketService, BTTicketSevice>();
builder.Services.AddScoped<IProjectSevice, ProjectService>();



builder.Services.AddMvc();

var app = builder.Build();

var scope = app.Services.CreateScope();
await DataUtility.ManageDataAsync(scope.ServiceProvider);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Contact}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
