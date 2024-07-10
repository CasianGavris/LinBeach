using LinBeach.Data;
using LinBeach.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<LinBeachDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LinBeachDbConnectionString"),
     sqlServerOptionsAction: sqlOptions =>
     {
         sqlOptions.EnableRetryOnFailure(
             maxRetryCount: 5, // Maximum number of retries
             maxRetryDelay: TimeSpan.FromSeconds(30), // Delay between retries
             errorNumbersToAdd: null); // SQL error numbers to consider for retries
     }));
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnectionString"),
     sqlServerOptionsAction: sqlOptions =>
     {
         sqlOptions.EnableRetryOnFailure(
             maxRetryCount: 5, // Maximum number of retries
             maxRetryDelay: TimeSpan.FromSeconds(30), // Delay between retries
             errorNumbersToAdd: null); // SQL error numbers to consider for retries
     }));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders(); 
builder.Services.AddScoped<IEventPostRep, EventPostRep>();
builder.Services.AddScoped<IImageRep, ImageRepCloud>();
builder.Services.AddScoped<IUserRep, UserRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
