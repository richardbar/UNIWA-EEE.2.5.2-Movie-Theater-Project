using MovieTheaterProject.Contracts.Responses;
using MovieTheaterProject.Domain;

namespace MovieTheaterProject.Mapping;

public static class DomainToApiContractMapper
{
    public static MovieResponse ToMovieResponse(this Movie movie)
    {
        return new()
        {
            Id = movie.Id.Value,
            Name = movie.Name.Value,
            Price = movie.Price.Value,
            Duration = movie.Duration.Value
        };
    }

    public static GetAllMoviesResponse ToMoviesResponse(this IEnumerable<Movie> movies)
    {
        return new()
        {
            Movies = movies.Select(movie => new MovieResponse
            {
                Id = movie.Id.Value,
                Name = movie.Name.Value,
                Price = movie.Price.Value,
                Duration = movie.Duration.Value
            })
        };
    }
}
