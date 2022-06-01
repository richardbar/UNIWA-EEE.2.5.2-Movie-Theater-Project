namespace MovieTheaterProject.API.Endpoints.MovieViewing;

[HttpGet("/api/movieviewings"), AllowAnonymous]
public sealed class GetAllMovieViewingsEndpoint : EndpointWithoutRequest<GetAllMovieViewingsResponse>
{
    private readonly IMovieViewingService _movieViewingService;

    public GetAllMovieViewingsEndpoint(IMovieViewingService movieViewingService)
    {
        _movieViewingService = movieViewingService;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var movieViewings = await _movieViewingService.GetAllAsync();
        var movieViewingsResponse = movieViewings.ToMovieViewingResponse();
        await SendOkAsync(movieViewingsResponse);
    }
}
