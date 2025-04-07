using SolutionTask.Utils.StockMarketConnectors.BitfinexConnector.Rest;
using StockMarketConnector.Connectors.Rest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRestConnector, BitfinexRestConnector>();

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();