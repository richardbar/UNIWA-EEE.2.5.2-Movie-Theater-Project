using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Contracts.Responses;
using MovieTheaterProject.Services;
using MovieTheaterProject.Mapping;

namespace MovieTheaterProject.Endpoints;

[HttpPut("api/movies/{id:guid}"), AllowAnonymous]
public sealed class UpdateMovieEndpoint : Endpoint<UpdateMovieRequest, MovieResponse>
{
    private readonly IMovieService _movieService;

    public UpdateMovieEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(UpdateMovieRequest req, CancellationToken ct)
    {
        var existingMovie = await _movieService.GetAsync(req.Id);

        if (existingMovie is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        req.Duration = existingMovie.Duration.Value;
        var movie = req.ToMovie();
        await _movieService.UpdateAsync(movie);

        var movieResponse = movie.ToMovieResponse();
        await SendOkAsync(movieResponse, ct);
    }
}
