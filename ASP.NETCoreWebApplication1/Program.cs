using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "";
        options.AccessDeniedPath = "";
    });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:7143", "https://localhost:44477", "https://localhost:44366",
                "https://localhost:33863").AllowCredentials();
            policy.WithMethods("PUT", "GET", "POST", "DELETE");
            policy.WithExposedHeaders("*");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});


builder.Services.AddHttpContextAccessor();

// Add services to the container.

builder.Services.AddControllers();
//Start app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy(new CookiePolicyOptions());

app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();