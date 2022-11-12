using Geens.Api.Datas;
using Geens.Api.Extensions;
using MsCommun.Extensions;
using Serilog;

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

if (builder.Environment.IsProduction())
{
    builder.Services.AddSqlServerDbConfiguration<EnseignantDbContext>(builder.Configuration.GetConnectionString("appConnString"));
}
else
{
    builder.Services.AddInMemoryDataBaseConfiguration<EnseignantDbContext>("InMem");
}


builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureControllerServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AjoutterCoucheDesProxies(builder.Configuration);


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
