using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.Mapping;
using MovieTheaterProject.Contracts.Requests.Movie;
using MovieTheaterProject.Contracts.Responses.MovieTheater;
using MovieTheaterProject.Services.MovieTheater;

namespace MovieTheaterProject.Endpoints.MovieTheater;

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
