using MovieTheaterProject.Repositories;

namespace MovieTheaterProject.Installer;

public sealed class RepositoryInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        services.AddSingleton<IMovieTheaterRepository, MovieTheaterRepository>();
    }
}
