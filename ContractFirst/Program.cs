using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configure app to serve ServiceDefinition.yaml static swagger-ui
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