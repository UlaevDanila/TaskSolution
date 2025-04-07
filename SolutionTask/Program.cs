var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<HttpClient>();

var app = builder.Build();


app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RestApi}/{action=GetTrade}/{id?}");

app.Run();