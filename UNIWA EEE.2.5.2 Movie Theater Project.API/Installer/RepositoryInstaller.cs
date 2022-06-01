using MovieTheaterProject.API.Repositories.Movie;
using MovieTheaterProject.API.Repositories.MovieTheater;
using MovieTheaterProject.API.Repositories.MovieViewing;
using MovieTheaterProject.API.Repositories.Reservation;

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
