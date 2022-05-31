using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.API.Services.MovieViewing;
using MovieTheaterProject.API.Contracts.Requests.MovieViewing;

namespace MovieTheaterProject.API.Endpoints.MovieViewing;

[HttpDelete("api/movieviewings/{id:guid}"), AllowAnonymous]
public sealed class DeleteMovieViewingEndpoint : Endpoint<DeleteMovieViewingRequest>
{
    private readonly IMovieViewingService _movieViewingService;

    public DeleteMovieViewingEndpoint(IMovieViewingService movieViewingService)
    {
        _movieViewingService = movieViewingService;
    }

    public override async Task HandleAsync(DeleteMovieViewingRequest req, CancellationToken ct)
    {
        var deleted = await _movieViewingService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
