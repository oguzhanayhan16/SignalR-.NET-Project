using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var requireAuthorize = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();




builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorize));
});
builder.Services.AddHttpClient();

builder.Services.ConfigureApplicationCookie(opt => 
{
    opt.LoginPath = "/Login/Index";
});

var app = builder.Build();

app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == 404)
    {
        x.HttpContext.Response.Redirect("/Error/NotFoundPage/");
    }
});



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
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();
