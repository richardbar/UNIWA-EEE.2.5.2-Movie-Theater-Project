namespace MovieTheaterProject.API.Endpoints.MovieViewing;

[HttpGet("/api/movieviewings/{id:guid}"), AllowAnonymous]
public sealed class GetMovieViewingEndpoint : Endpoint<GetMovieViewingRequest, MovieViewingResponse>
{
    private readonly IMovieViewingService _movieViewingService;

    public GetMovieViewingEndpoint(IMovieViewingService movieViewingService)
    {
        _movieViewingService = movieViewingService;
    }

    public override async Task HandleAsync(GetMovieViewingRequest req, CancellationToken ct)
    {
        var movieViewing = await _movieViewingService.GetAsync(req.Id);

        if (movieViewing is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var movieViewingResponse = movieViewing.ToMovieViewingResponse();
        await SendOkAsync(movieViewingResponse, ct);
    }
}
