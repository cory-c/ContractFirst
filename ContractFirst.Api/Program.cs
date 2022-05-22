using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();

// Configure app to serve ServiceDefinition.yaml static file on swagger-ui
var app = builder.Build();
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".yaml"] = "text/yaml";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseAuthorization();
app.MapControllers();
app.Run();