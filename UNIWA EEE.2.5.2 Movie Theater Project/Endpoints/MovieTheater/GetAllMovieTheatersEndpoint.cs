using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.Mapping;
using MovieTheaterProject.Contracts.Responses.MovieTheater;
using MovieTheaterProject.Services.MovieTheater;

namespace MovieTheaterProject.Endpoints.MovieTheater;

[HttpGet("/api/movietheaters"), AllowAnonymous]
public class GetAllMovieTheatersEndpoint : EndpointWithoutRequest<GetAllMovieTheatersResponse>
{
    private readonly IMovieTheaterService _movieTheaterService;

    public GetAllMovieTheatersEndpoint(IMovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var movieTheaters = await _movieTheaterService.GetAllAsync();
        var movieTheatersResponse = movieTheaters.ToMovieTheaterResponse();
        await SendOkAsync(movieTheatersResponse);
    }
}
