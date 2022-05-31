using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Contracts.Requests.MovieViewing;
using MovieTheaterProject.API.Contracts.Responses.MovieViewing;
using MovieTheaterProject.API.Services.MovieViewing;
using MovieTheaterProject.API.Services.Movie;
using MovieTheaterProject.API.Domain.Common;

namespace MovieTheaterProject.API.Endpoints.MovieViewing;

[HttpPost("/api/movieviewings"), AllowAnonymous]
public sealed class CreateMovieViewingEndpoint : Endpoint<CreateMovieViewingRequest, MovieViewingResponse>
{
    private readonly IMovieViewingService _movieViewingService;
    private readonly IMovieService _movieService;

    public CreateMovieViewingEndpoint(
        IMovieViewingService movieViewingService,
        IMovieService movieService)
    {
        _movieViewingService = movieViewingService;
        _movieService = movieService;
    }

    public override async Task HandleAsync(CreateMovieViewingRequest req, CancellationToken ct)
    {
        var movieViewing = req.ToMovieViewing();
        var movie = await _movieService.GetAsync(Guid.Parse(req.MovieId));
        movieViewing.Duration = Time.From(movie!.Duration.Value);

        await _movieViewingService.CreateAsync(movieViewing);

        var movieViewingResponse = movieViewing.ToMovieViewingResponse();
        await SendCreatedAtAsync<GetMovieViewingEndpoint>(
            new { Id = movieViewing.Id.Value }, movieViewingResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
