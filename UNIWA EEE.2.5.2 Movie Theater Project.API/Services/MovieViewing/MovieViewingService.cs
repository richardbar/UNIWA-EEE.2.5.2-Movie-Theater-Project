using FluentValidation;
using FluentValidation.Results;

using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Repositories.Movie;
using MovieTheaterProject.API.Repositories.MovieTheater;
using MovieTheaterProject.API.Repositories.MovieViewing;
using MovieTheaterProject.API.Repositories.Reservation;

namespace MovieTheaterProject.API.Services.MovieViewing;

public class MovieViewingService : IMovieViewingService
{
    private readonly IMovieViewingRepository _movieViewingRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieTheaterRepository _movieTheaterRepository;
    private readonly IReservationRepository _reservationRepository;

    public MovieViewingService(
        IMovieViewingRepository movieViewingRepository,
        IMovieRepository movieRepository,
        IMovieTheaterRepository movieTheaterRepository,
        IReservationRepository reservationRepository)
    {
        _movieViewingRepository = movieViewingRepository;
        _movieRepository = movieRepository;
        _movieTheaterRepository = movieTheaterRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<bool> CreateAsync(Domain.MovieViewing movieViewing)
    {
        bool movieFound = (await _movieRepository.GetAsync(movieViewing.MovieId.Value)) is not null;
        bool movieTheaterFound = (await _movieTheaterRepository.GetAsync(movieViewing.MovieTheaterId.Value)) is not null;

        if (!movieFound || !movieTheaterFound)
        {
            var valFailures = new List<ValidationFailure>();
            if (!movieFound)
            {
                var message = $"A movie with the id {movieViewing.MovieId.Value} was not found";
                valFailures.Add(new ValidationFailure(nameof(MovieViewing), message));
            }
            if (!movieTheaterFound)
            {
                var message = $"A movie with the id {movieViewing.MovieId.Value} was not found";
                valFailures.Add(new ValidationFailure(nameof(MovieViewing), message));
            }

            throw new ValidationException("A valid movie id and movie theater id is required", valFailures.ToArray());
        }

        var movieViewingDto = movieViewing.ToMovieViewingDto();
        return await _movieViewingRepository.CreateAsync(movieViewingDto);
    }

    public async Task<Domain.MovieViewing?> GetAsync(Guid id)
    {
        var movieVewingrDto = await _movieViewingRepository.GetAsync(id);
        return movieVewingrDto?.ToMovieViewing();
    }

    public async Task<IEnumerable<Domain.MovieViewing>> GetAllAsync()
    {
        var movieVewingrDtos = await _movieViewingRepository.GetAllAsync();
        return movieVewingrDtos.Select(movieVewingrDto => movieVewingrDto.ToMovieViewing());
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        if ((await _reservationRepository.GetAsyncByMovieViewingId(id)).Count() != 0)
        {
            var message = $"At least a reservation for the movie viewing with the id {id}";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(MovieViewing), message)
            });
        }
        return await _movieViewingRepository.DeleteAsync(id);
    }
}
