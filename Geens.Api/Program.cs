using MsCommun.Extensions;
using Serilog;
using Geens.Ioc;
using Geens.Features.Proxies.GdcProxys;

var builder = WebApplication.CreateBuilder(args);

// Configuration Serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


Log.Information("GDE Demmarre demarre ");
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));


// configuration des options dans le services
builder.Services.Configure<GdcProxyOptions>(builder.Configuration.GetSection(GdcProxyOptions.Path));


builder.Services.AjoutDeToutesLesExtensions(builder.Configuration);
builder.Services.AddConfigurationMassTransitWithRabbitMQ(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
