using MobileWorld.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

//add serilog
builder.Host.ConfigureSerilog();

builder.Services.ConfigureStartupConfiguration(builder.Configuration);

var app = builder.Build().UseStartupConfiguration();

app.Run();

