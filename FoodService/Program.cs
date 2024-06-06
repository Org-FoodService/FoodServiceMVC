using FoodService.Config;

var builder = WebApplication.CreateBuilder(args);


// Add IOC
builder.Services.ConfigureHttpRequestIoc(builder);

builder.Services.AddControllersWithViews();

builder.Services.ConfigureGlobalization();

//// Add session services
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Middleware for error handling
    app.UseStatusCodePagesWithRedirects("/Home/Index"); // Middleware for redirecting not found pages
    app.UseHsts();
}

//app.UseHttpsRedirection(); // Redirects all HTTP requests to HTTPS
app.UseStaticFiles();

app.UseRouting();

app.ConfigureGlobalization();

//app.UseSession();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
