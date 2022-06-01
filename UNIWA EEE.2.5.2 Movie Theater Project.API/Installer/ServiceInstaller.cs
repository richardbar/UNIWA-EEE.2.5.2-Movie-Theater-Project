﻿using MovieTheaterProject.API.Services.Movie;
using MovieTheaterProject.API.Services.MovieTheater;
using MovieTheaterProject.API.Services.MovieViewing;
using MovieTheaterProject.API.Services.Reservation;

namespace MovieTheaterProject.API.Installer;

public sealed class ServiceInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMovieService, MovieService>();
        services.AddSingleton<IMovieTheaterService, MovieTheaterService>();
        services.AddSingleton<IMovieViewingService, MovieViewingService>();
        services.AddSingleton<IReservationService, ReservationService>();
    }
}
