using System.Net.Http.Json;
using MovieTheaterProject.Domain.Contracts.Responses.MovieViewing;


namespace MovieTheaterProject.UI.Utilities.MovieViewingManager;

public sealed class MovieViewingManager : IMovieViewingManager
{
    private HttpClient _http;

    public MovieViewingManager(HttpClient http)
    {
        _http = http;
    }

    public async Task<MovieViewingResponse?> GetMovieViewingById(Guid movieViewingId) =>
        await _http.GetFromJsonAsync<MovieViewingResponse>($"api/movieviewings/{movieViewingId}");

    public async Task<MovieViewingResponse[]?> GetMovieViewingsByMovieId(Guid movieId)
    {
        var response = await _http.GetFromJsonAsync<GetAllMovieViewingsResponse>(
            $"api/movieviewings?MovieId={movieId}");

        if (response is null)
            return null;

       var movieViewings = response.MovieViewings.ToArray();

        return movieViewings;
    }

    public async Task DeleteMovieViewing(Guid movieViewingId)
    {
        await _http.DeleteAsync($"api/movieviewings/{movieViewingId}");
    }
}
