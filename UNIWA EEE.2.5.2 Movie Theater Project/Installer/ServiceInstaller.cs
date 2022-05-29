using MovieTheaterProject.Services.Movie;
using MovieTheaterProject.Services.MovieTheater;

namespace MovieTheaterProject.Installer;

public sealed class ServiceInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieService, MovieService>();
        services.AddSingleton<IMovieTheaterService, MovieTheaterService>();
    }
}
