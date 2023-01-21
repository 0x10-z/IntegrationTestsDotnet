using TemplateFormattedConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.EnableTemplatedConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/whoami", () =>
{
    return app.Configuration["FullName"];
});

app.Run();

// https://github.com/dotnet/AspNetCore.Docs/issues/23837
// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
namespace ExampleProject
{
    public class Program
    {
    }
}
