using MovieTheaterProject.Contracts.Responses.Movie;
using MovieTheaterProject.Contracts.Responses.MovieTheater;
using MovieTheaterProject.Domain;

namespace MovieTheaterProject.Mapping;

public static class DomainToApiContractMapper
{
    public static MovieTheaterResponse ToMovieTheaterResponse(this MovieTheater movieTheater)
    {
        return new()
        {
            Id = movieTheater.Id.Value,
            Name = movieTheater.Name.Value,
            Rows = movieTheater.Rows.Value,
            Columns = movieTheater.Columns.Value
        };
    }

    public static GetAllMovieTheatersResponse ToMovieTheaterResponse(this IEnumerable<MovieTheater> movieTheaters)
    {
        return new()
        {
            MovieTheaters = movieTheaters.Select(movieTheater => new MovieTheaterResponse
            {
                Id = movieTheater.Id.Value,
                Name = movieTheater.Name.Value,
                Rows = movieTheater.Rows.Value,
                Columns = movieTheater.Columns.Value
            })
        };
    }

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
