using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Contracts.Responses.Movie;
using MovieTheaterProject.API.Services.Movie;

namespace MovieTheaterProject.API.Endpoints.Movie;

[HttpGet("/api/movies"), AllowAnonymous]
public class GetAllMoviesEndpoint : EndpointWithoutRequest<GetAllMoviesResponse>
{
    private readonly IMovieService _movieService;

    public GetAllMoviesEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var movies = await _movieService.GetAllAsync();
        var moviesResponse = movies.ToMoviesResponse();
        await SendOkAsync(moviesResponse);
    }
}
