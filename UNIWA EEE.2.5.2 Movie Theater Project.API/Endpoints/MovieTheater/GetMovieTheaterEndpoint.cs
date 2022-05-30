using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Contracts.Requests.Movie;
using MovieTheaterProject.API.Contracts.Responses.MovieTheater;
using MovieTheaterProject.API.Services.MovieTheater;

namespace MovieTheaterProject.API.Endpoints.MovieTheater;

[HttpGet("/api/movietheaters/{id:guid}"), AllowAnonymous]
public sealed class GetMovieTheaterEndpoint : Endpoint<GetMovieRequest, MovieTheaterResponse>
{
    private readonly IMovieTheaterService _movieTheaterService;

    public GetMovieTheaterEndpoint(IMovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }

    public override async Task HandleAsync(GetMovieRequest req, CancellationToken ct)
    {
        var movieTheater = await _movieTheaterService.GetAsync(req.Id);

        if (movieTheater is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var movieTheaterResponse = movieTheater.ToMovieTheaterResponse();
        await SendOkAsync(movieTheaterResponse, ct);
    }
}
