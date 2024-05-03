using FoodService.Config.Ioc;
using FoodService.Config;
using FoodService.Config.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Get the database connection string from appsettings.json
string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add connection to Database
builder.Services.ConfigureDatabase(mySqlConnection);
builder.Services.UpdateMigrationDatabase();

builder.Services.ConfigureAuthentication(builder);

// Add IOC
builder.Services.ConfigureRepositoryIoc();
builder.Services.ConfigureServiceIoc();
builder.Services.ConfigureCommandIoc();

builder.Services.AddControllersWithViews(options =>
{
    // Add the global custom exception filter
    //options.Filters.Add(new CustomExceptionFilterAttribute());
});

builder.Services.ConfigureGlobalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Middleware for error handling
    //app.UseStatusCodePagesWithRedirects("/Home/Index"); // Middleware for redirecting not found pages
    app.UseHsts();
}

//app.UseHttpsRedirection(); // Redirects all HTTP requests to HTTPS
app.UseStaticFiles();

app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    await scope.AddAdminRole();
    await scope.AddEmployeeRole();
}

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureGlobalization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "LocalizedDefault",
        pattern: "{culture}/{controller=Home}/{action=Index}/{id?}",
        constraints: new { culture = new CultureRouteConstraint() });

    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
