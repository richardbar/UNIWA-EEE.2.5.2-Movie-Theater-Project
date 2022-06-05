namespace MovieTheaterProject.API.Endpoints.MovieViewing;

[HttpGet("/api/movieviewings"), AllowAnonymous]
public sealed class GetAllMovieViewingsEndpoint : Endpoint<GetAllMovieViewingsRequest, GetAllMovieViewingsResponse>
{
    private readonly IMovieViewingService _movieViewingService;

    public GetAllMovieViewingsEndpoint(IMovieViewingService movieViewingService)
    {
        _movieViewingService = movieViewingService;
    }

    public override async Task HandleAsync(GetAllMovieViewingsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Entities.MovieViewing> movieViewings = default!;
        if (request.MovieId is not null && request.MovieTheaterId is null)
            movieViewings = await _movieViewingService.GetAllByMovieIdAsync((Guid)request.MovieId);
        else if (request.MovieTheaterId is not null && request.MovieId is null)
            movieViewings = await _movieViewingService.GetAllByMovieTheaterIdAsync((Guid)request.MovieTheaterId);
        else
            movieViewings = await _movieViewingService.GetAllAsync();

        var movieViewingsResponse = movieViewings.ToMovieViewingResponse();
        await SendOkAsync(movieViewingsResponse);
    }
}
