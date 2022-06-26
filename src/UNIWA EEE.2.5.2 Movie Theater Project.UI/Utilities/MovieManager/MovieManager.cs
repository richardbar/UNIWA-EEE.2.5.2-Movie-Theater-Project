using System.Net.Http.Json;

using MovieTheaterProject.Domain.Contracts.Requests.Movie;
using MovieTheaterProject.Domain.Contracts.Responses.Movie;

namespace MovieTheaterProject.UI.Utilities.MovieManager;

public sealed class MovieManager : IMovieManager
{
    private static readonly string s_apiURL = "api/movies";
    private HttpClient _http;

    public MovieManager(HttpClient http)
    {
        _http = http;
    }

    public async Task<MovieResponse?> GetMovieById(Guid movieId)
    {
        try
        {
            return await _http.GetFromJsonAsync<MovieResponse>($"{s_apiURL}/{movieId}");
        }
        catch
        {
            return null;
        }
    }

    public async Task<MovieResponse[]?> GetAllMovies()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<GetAllMoviesResponse>(s_apiURL);

            return response?.Movies.ToArray();
        }
        catch
        {
            return null;
        }
    }

    public async Task<MovieResponse?> CreateMovie(string movieName, string movieDescription, float moviePrice, long movieDuration)
    {
        try
        {
            var createMovieRequest = new CreateMovieRequest
            {
                Name = movieName,
                Description = movieDescription,
                Price = moviePrice,
                Duration = movieDuration
            };

            using var response = await _http.PostAsJsonAsync<CreateMovieRequest>(s_apiURL, createMovieRequest);

            var movie = await response.Content.ReadFromJsonAsync<MovieResponse>();

            return movie;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteMovie(Guid movieId)
    {
        using var response = await _http.DeleteAsync($"{s_apiURL}/{movieId}");

        return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }
}
