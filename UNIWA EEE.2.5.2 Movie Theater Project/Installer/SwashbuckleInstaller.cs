using FastEndpoints.Swagger;

namespace MovieTheaterProject.Installer;

public sealed class SwashbuckleInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerDoc(settings =>
        {
            settings.Title = "Movie Theater API";
            settings.Version = "v1";
        });
    }
}
