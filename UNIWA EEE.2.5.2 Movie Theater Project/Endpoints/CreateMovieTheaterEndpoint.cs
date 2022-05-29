using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Contracts.Responses;
using MovieTheaterProject.Mapping;
using MovieTheaterProject.Services;

namespace MovieTheaterProject.Endpoints;

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
