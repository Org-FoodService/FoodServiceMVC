using FoodService.Config.Ioc;
using FoodService.Config;

var builder = WebApplication.CreateBuilder(args);

// Get the database connection string from appsettings.json
string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(mySqlConnection);

// Add connection to Database
builder.Services.ConfigureDatabase(mySqlConnection);
builder.Services.UpdateMigrationDatabase();

builder.Services.ConfigureAuthentication(builder);

// Add IOC
builder.Services.ConfigureRepositoryIoc();
builder.Services.ConfigureServiceIoc();
builder.Services.ConfigureCommandIoc();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Middleware for error handling
    //app.UseStatusCodePagesWithRedirects("/Home/Index"); // Middleware for redirecting not found pages
    app.UseHsts();
}

Console.WriteLine("Passou aqui");
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

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
Console.WriteLine("Passou aqui2");

app.Run();
