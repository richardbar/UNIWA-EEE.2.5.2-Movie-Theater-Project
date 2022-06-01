namespace MovieTheaterProject.API.Installer;

public sealed class RepositoryInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        services.AddSingleton<IMovieTheaterRepository, MovieTheaterRepository>();
        services.AddSingleton<IMovieViewingRepository, MovieViewingRepository>();
        services.AddSingleton<IReservationRepository, ReservationRepository>();
    }
}
