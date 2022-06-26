using System.Net.Http.Json;
using MovieTheaterProject.Domain.Contracts.Responses.MovieTheater;

namespace MovieTheaterProject.UI.Utilities.MovieTheaterManager;

public sealed class MovieTheaterManager : IMovieTheaterManager
{
    private static readonly string s_apiURL = "api/movietheaters";
    private HttpClient _http;

    public MovieTheaterManager(HttpClient http)
    {
        _http = http;
    }

    public async Task<MovieTheaterResponse?> GetMovieTheaterById(Guid movieTheaterId)
    {
        try
        {
            return await _http.GetFromJsonAsync<MovieTheaterResponse>($"{s_apiURL}/{movieTheaterId}");
        }
        catch
        {
            return null;
        }
    }

    public async Task<MovieTheaterResponse[]?> GetAllMovieTheaters()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<GetAllMovieTheatersResponse>(s_apiURL);

            return response?.MovieTheaters.ToArray();
        }
        catch
        {
            return null;
        }
    }
}
