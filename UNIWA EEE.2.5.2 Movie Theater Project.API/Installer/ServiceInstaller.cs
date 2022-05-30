using MovieTheaterProject.API.Services.Movie;
using MovieTheaterProject.API.Services.MovieTheater;

namespace MovieTheaterProject.API.Installer;

public sealed class ServiceInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieService, MovieService>();
        services.AddSingleton<IMovieTheaterService, MovieTheaterService>();
    }
}
