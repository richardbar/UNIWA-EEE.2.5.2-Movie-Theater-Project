namespace MovieTheaterProject.API.Endpoints.MovieTheater;

[HttpDelete("api/movietheaters/{id:guid}"), AllowAnonymous]
public sealed class DeleteMovieTheaterEndpoint : Endpoint<DeleteMovieTheaterRequest>
{
    private readonly IMovieTheaterService _movieTheaterService;

    public DeleteMovieTheaterEndpoint(IMovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }

    public override async Task HandleAsync(DeleteMovieTheaterRequest req, CancellationToken ct)
    {
        var deleted = await _movieTheaterService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
