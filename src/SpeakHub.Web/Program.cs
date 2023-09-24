using Microsoft.OpenApi.Models;
using SpeakHub.Configuration.LayerConfigurations;
using SpeakHub.Configurations.LayerConfigurations;
using SpeakHub.Midllewares;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureDataAccess(builder.Configuration);
builder.Services.AddWeb(builder.Configuration);
builder.Services.AddService();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "SeakHubAPI.swagger", Version = "v2" });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "SeakHubAPI.swagger");
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{    
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeakHub API V1");
    c.RoutePrefix = "area/swagger";
});
app.UseMiddleware<TokenRedirectMiddleware>();

app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.HttpContext.Response.Redirect("accounts/login");
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapAreaControllerRoute(
    name: "users",
    areaName: "users",
    pattern: "users/{controller=Home}/{action=Index}/{id?}");*/

app.MapAreaControllerRoute(
   name: "administrator",
   areaName: "Administrator",
   pattern: "administrator/{controller=Home}/{action=Index}/{id?}");

app.Run();