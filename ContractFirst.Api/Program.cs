using ContractFirst.HealthCheck;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

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

app.MapHealthChecks("healthcheck");
app.UseAuthorization();
app.MapControllers();
app.Run();