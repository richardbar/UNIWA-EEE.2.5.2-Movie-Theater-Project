using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Contracts.Responses;
using MovieTheaterProject.Services;
using MovieTheaterProject.Mapping;

namespace MovieTheaterProject.Endpoints;

[HttpPut("api/movietheaters/{id:guid}"), AllowAnonymous]
public sealed class UpdateMovieTheaterEndpoint : Endpoint<UpdateMovieTheaterRequest, MovieTheaterResponse>
{
    private readonly IMovieTheaterService _movieTheaterService;

    public UpdateMovieTheaterEndpoint(IMovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }

    public override async Task HandleAsync(UpdateMovieTheaterRequest req, CancellationToken ct)
    {
        var existingMovieTheater = await _movieTheaterService.GetAsync(req.Id);

        if (existingMovieTheater is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var movieTheater = req.ToMovieTheater();
        await _movieTheaterService.UpdateAsync(movieTheater);

        var movieTheaterResponse = movieTheater.ToMovieTheaterResponse();
        await SendOkAsync(movieTheaterResponse, ct);
    }
}
