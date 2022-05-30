using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Contracts.Requests.Movie;
using MovieTheaterProject.API.Contracts.Responses.Movie;
using MovieTheaterProject.API.Services.Movie;

namespace MovieTheaterProject.API.Endpoints.Movie;

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
