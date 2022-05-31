using FluentValidation;
using FluentValidation.Results;

using MovieTheaterProject.API.Domain;
using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Repositories.MovieTheater;
using MovieTheaterProject.API.Repositories.MovieViewing;

namespace MovieTheaterProject.API.Services.MovieTheater;

public sealed class MovieTheaterService : IMovieTheaterService
{
    private readonly IMovieTheaterRepository _movieTheaterRepository;
    private readonly IMovieViewingRepository _movieViewingRepository;

    public MovieTheaterService(
        IMovieTheaterRepository movieTheaterRepository,
        IMovieViewingRepository movieViewingRepository)
    {
        _movieTheaterRepository = movieTheaterRepository;
        _movieViewingRepository = movieViewingRepository;
    }

    public async Task<bool> CreateAsync(Domain.MovieTheater movieTheater)
    {
        var existingMovieTheater = await _movieTheaterRepository.GetAsync(movieTheater.Id.Value);
        if (existingMovieTheater is not null)
        {
            var message = $"A movie theater with the id {movieTheater.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(MovieTheater), message)
            });
        }

        var movieTheaterDto = movieTheater.ToMovieTheaterDto();
        return await _movieTheaterRepository.CreateAsync(movieTheaterDto);
    }

    public async Task<Domain.MovieTheater?> GetAsync(Guid id)
    {
        var movieTheaterDto = await _movieTheaterRepository.GetAsync(id);
        return movieTheaterDto?.ToMovieTheater();
    }

    public async Task<IEnumerable<Domain.MovieTheater>> GetAllAsync()
    {
        var movieThaterDtos = await _movieTheaterRepository.GetAllAsync();
        return movieThaterDtos.Select(movieTheaterDto => movieTheaterDto.ToMovieTheater());
    }

    public async Task<bool> UpdateAsync(Domain.MovieTheater movieTheater)
    {
        var movieTheaterDto = movieTheater.ToMovieTheaterDto();
        return await _movieTheaterRepository.UpdateAsync(movieTheaterDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        if ((await _movieViewingRepository.GetAsyncByMovieTheaterId(id)).Count() != 0)
        {
            var message = $"At least a movie viewing is scheduled for the movie theater with the id {id}";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(MovieTheater), message)
            });
        }

        return await _movieTheaterRepository.DeleteAsync(id);
    }
}
