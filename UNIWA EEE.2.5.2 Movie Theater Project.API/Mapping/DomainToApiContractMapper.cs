﻿using MovieTheaterProject.API.Contracts.Responses.Movie;
using MovieTheaterProject.API.Contracts.Responses.MovieTheater;
using MovieTheaterProject.API.Contracts.Responses.MovieViewing;
using MovieTheaterProject.API.Domain;

namespace MovieTheaterProject.API.Mapping;

public static class DomainToApiContractMapper
{
    public static MovieViewingResponse ToMovieViewingResponse(this MovieViewing movieViewing)
    {
        return new()
        {
            Id = movieViewing.Id.Value,
            MovieId = movieViewing.MovieId.Value,
            MovieTheaterId = movieViewing.MovieTheaterId.Value,
            StartTime = movieViewing.StartTime.Value,
            Duration = movieViewing.Duration.Value
        };
    }

    public static GetAllMovieViewingsResponse ToMovieViewingResponse(this IEnumerable<MovieViewing> movieViewings)
    {
        return new()
        {
            MovieViewings = movieViewings.Select(movieViewing => new MovieViewingResponse
            {
                Id = movieViewing.Id.Value,
                MovieId = movieViewing.MovieId.Value,
                MovieTheaterId = movieViewing.MovieTheaterId.Value,
                StartTime = movieViewing.StartTime.Value,
                Duration = movieViewing.Duration.Value
            })
        };
    }

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
