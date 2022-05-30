using FluentValidation;
using FluentValidation.Results;

using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Repositories.Movie;

namespace MovieTheaterProject.API.Services.Movie;

public sealed class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<bool> CreateAsync(Domain.Movie movie)
    {
        var existingMovie = await _movieRepository.GetAsync(movie.Id.Value);
        if (existingMovie is not null)
        {
            var message = $"A movie with the id {movie.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Movie), message)
            });
        }

        var movieDto = movie.ToMovieDto();
        return await _movieRepository.CreateAsync(movieDto);
    }

    public async Task<Domain.Movie?> GetAsync(Guid id)
    {
        var movieDto = await _movieRepository.GetAsync(id);
        return movieDto?.ToMovie();
    }

    public async Task<IEnumerable<Domain.Movie>> GetAllAsync()
    {
        var movieDtos = await _movieRepository.GetAllAsync();
        return movieDtos.Select(movieDto => movieDto.ToMovie());
    }

    public async Task<bool> UpdateAsync(Domain.Movie movie)
    {
        var movieDto = movie.ToMovieDto();
        return await _movieRepository.UpdateAsync(movieDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _movieRepository.DeleteAsync(id);
    }
}
