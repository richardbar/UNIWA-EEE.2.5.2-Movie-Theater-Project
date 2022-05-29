using MovieTheaterProject.Services;

namespace MovieTheaterProject.Installer;

public sealed class ServiceInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieService, MovieService>();
    }
}
