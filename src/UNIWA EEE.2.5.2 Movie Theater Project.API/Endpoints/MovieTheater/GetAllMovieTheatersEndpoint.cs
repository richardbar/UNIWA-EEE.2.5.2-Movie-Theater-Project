namespace MovieTheaterProject.API.Endpoints.MovieTheater;

[HttpGet("/api/movietheaters"), AllowAnonymous]
public class GetAllMovieTheatersEndpoint : EndpointWithoutRequest<GetAllMovieTheatersResponse>
{
    private readonly IMovieTheaterService _movieTheaterService;

    public GetAllMovieTheatersEndpoint(IMovieTheaterService movieTheaterService)
    {
        _movieTheaterService = movieTheaterService;
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var movieTheaters = await _movieTheaterService.GetAllAsync();
        var movieTheatersResponse = movieTheaters.ToMovieTheaterResponse();
        await SendOkAsync(movieTheatersResponse);
    }
}
