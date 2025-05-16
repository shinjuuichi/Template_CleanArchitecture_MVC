using BusinessLogicLayer;
using BusinessLogicLayer.Commons;
using PresentationLayer;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.Get<AppConfiguration>()!;
builder.Services.AddSingleton(configuration);
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddWebAPIServices(configuration);

var app = builder.Build();
app.UseWebAPIServices();

app.Run();
