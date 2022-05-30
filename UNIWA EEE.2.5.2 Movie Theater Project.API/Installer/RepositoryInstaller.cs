using MovieTheaterProject.API.Repositories.Movie;
using MovieTheaterProject.API.Repositories.MovieTheater;

namespace MovieTheaterProject.API.Installer;

public sealed class RepositoryInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        services.AddSingleton<IMovieTheaterRepository, MovieTheaterRepository>();
    }
}
