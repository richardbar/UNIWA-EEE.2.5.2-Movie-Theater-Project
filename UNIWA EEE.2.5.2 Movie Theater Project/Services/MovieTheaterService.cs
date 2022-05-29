using FluentValidation;
using FluentValidation.Results;

using MovieTheaterProject.Domain;
using MovieTheaterProject.Mapping;
using MovieTheaterProject.Repositories;

namespace MovieTheaterProject.Services;

public sealed class MovieTheaterService : IMovieTheaterService
{
    private readonly IMovieTheaterRepository _movieTheaterRepository;

    public MovieTheaterService(IMovieTheaterRepository movieTheaterRepository)
    {
        _movieTheaterRepository = movieTheaterRepository;
    }

    public async Task<bool> CreateAsync(MovieTheater movieTheater)
    {
        var existingMovieTheater = await _movieTheaterRepository.GetAsync(movieTheater.Id.Value);
        if (existingMovieTheater is not null)
        {
            var message = $"A movie theater with the id {movieTheater.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Movie), message)
            });
        }

        var movieTheaterDto = movieTheater.ToMovieTheaterDto();
        return await _movieTheaterRepository.CreateAsync(movieTheaterDto);
    }

    public async Task<MovieTheater?> GetAsync(Guid id)
    {
        var movieTheaterDto = await _movieTheaterRepository.GetAsync(id);
        return movieTheaterDto?.ToMovieTheater();
    }

    public async Task<IEnumerable<MovieTheater>> GetAllAsync()
    {
        var movieThaterDtos = await _movieTheaterRepository.GetAllAsync();
        return movieThaterDtos.Select(movieTheaterDto => movieTheaterDto.ToMovieTheater());
    }

    public async Task<bool> UpdateAsync(MovieTheater movieTheater)
    {
        var movieTheaterDto = movieTheater.ToMovieTheaterDto();
        return await _movieTheaterRepository.UpdateAsync(movieTheaterDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _movieTheaterRepository.DeleteAsync(id);
    }
}
