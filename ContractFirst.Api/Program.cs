using ContractFirst.Configuration;
using ContractFirst.HealthCheck;
using Microsoft.AspNetCore.StaticFiles;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

// Setup configuration server
var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var configBuilder = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddConfigServer(env, loggerFactory)
    .AddEnvironmentVariables();
var config = configBuilder.Build();

// read config into options
builder.Services.AddOptions();
builder.Services.AddOptions<AppConfig>()
    .Bind(builder.Configuration.GetSection("AppConfig"))
    .ValidateDataAnnotations() //TODO add validations
    .ValidateOnStart(); // TODO create sample controller with IOptionsMonitor

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample Health Check");

// Configure app to serve ServiceDefinition.yaml static file on swagger-ui
var app = builder.Build();
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".yaml"] = "text/yaml";
app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });

// Setup health check.
// TODO: add build settings / custom response
app.MapHealthChecks("healthcheck");
app.UseAuthorization();
app.MapControllers();
app.Run();