using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Contracts.Requests.MovieTheater;
using MovieTheaterProject.API.Contracts.Responses.MovieTheater;
using MovieTheaterProject.API.Services.MovieTheater;

namespace MovieTheaterProject.API.Endpoints.MovieTheater;

[HttpPost("/api/movietheaters"), AllowAnonymous]
public sealed class CreateMovieTheaterEndpoint : Endpoint<CreateMovieTheaterRequest, MovieTheaterResponse>
{
    private readonly IMovieTheaterService _movieTheaterService;

    public CreateMovieTheaterEndpoint(IMovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }

    public override async Task HandleAsync(CreateMovieTheaterRequest req, CancellationToken ct)
    {
        var movieTheater = req.ToMovieTheater();

        await _movieTheaterService.CreateAsync(movieTheater);

        var movieTheaterResponse = movieTheater.ToMovieTheaterResponse();
        await SendCreatedAtAsync<GetMovieTheaterEndpoint>(
            new { Id = movieTheater.Id.Value }, movieTheaterResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
