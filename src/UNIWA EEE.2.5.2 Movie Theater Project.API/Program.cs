using FastEndpoints;
using FastEndpoints.Swagger;
using MovieTheaterProject.API.Database;
using MovieTheaterProject.API.Installer;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var installers = typeof(Program).Assembly.ExportedTypes
            .Where(type => typeof(IInstaller).IsAssignableFrom(type) &&
                           !type.IsInterface &&
                           !type.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();

installers.ForEach(installer => installer.InstallService(builder.Services, builder.Configuration));


var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(s => s.ConfigureDefaults());
}

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();