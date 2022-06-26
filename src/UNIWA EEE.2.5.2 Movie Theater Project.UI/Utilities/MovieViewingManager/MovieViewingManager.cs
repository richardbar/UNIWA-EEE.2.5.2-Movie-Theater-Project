using System.Net.Http.Json;
using MovieTheaterProject.Domain.Contracts.Requests.MovieViewing;
using MovieTheaterProject.Domain.Contracts.Responses.MovieViewing;


namespace MovieTheaterProject.UI.Utilities.MovieViewingManager;

public sealed class MovieViewingManager : IMovieViewingManager
{
    private static readonly string s_apiURL = "api/movieviewings";
    private HttpClient _http;

    public MovieViewingManager(HttpClient http)
    {
        _http = http;
    }

    public async Task<MovieViewingResponse?> GetMovieViewingById(Guid movieViewingId) =>
        await _http.GetFromJsonAsync<MovieViewingResponse>($"{s_apiURL}/{movieViewingId}");

    public async Task<MovieViewingResponse[]?> GetMovieViewingsByMovieId(Guid movieId)
    {
        var response = await _http.GetFromJsonAsync<GetAllMovieViewingsResponse>(
            $"{s_apiURL}?MovieId={movieId}");

        if (response is null)
            return null;

       var movieViewings = response.MovieViewings.ToArray();

        return movieViewings;
    }

    public async Task<MovieViewingResponse?> CreateMovieViewing(Guid movieId, Guid movieTheaterId, long startTime)
    {
        try
        {
            var createMovieViewingRequest = new CreateMovieViewingRequest
            {
                MovieId = movieId.ToString(),
                MovieTheaterId = movieTheaterId.ToString(),
                StartTime = startTime
            };

            using var response = await _http.PostAsJsonAsync<CreateMovieViewingRequest>(s_apiURL, createMovieViewingRequest);

            var movie = await response.Content.ReadFromJsonAsync<MovieViewingResponse>();

            return movie;
        }
        catch
        {
            return null;
        }
    }

    public async Task DeleteMovieViewing(Guid movieViewingId)
    {
        await _http.DeleteAsync($"api/movieviewings/{movieViewingId}");
    }
}
