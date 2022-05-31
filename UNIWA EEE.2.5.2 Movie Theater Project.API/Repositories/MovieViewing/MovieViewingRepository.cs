using Dapper;

using MovieTheaterProject.API.Contracts.Data;
using MovieTheaterProject.API.Database;

namespace MovieTheaterProject.API.Repositories.MovieViewing;

public sealed class MovieViewingRepository : IMovieViewingRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public MovieViewingRepository(
        IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(MovieViewingDto movieViewing)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO MovieViewings (Id, MovieId, MovieTheaterId, StartTime, Duration) 
            VALUES (@Id, @MovieId, @MovieTheaterId, @StartTime, @Duration)",
            movieViewing);
        return result > 0;
    }

    public async Task<MovieViewingDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<MovieViewingDto>(
            "SELECT * FROM MovieViewings WHERE Id = @Id LIMIT 1",
            new { Id = id.ToString() });
    }

    public async Task<IEnumerable<MovieViewingDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<MovieViewingDto>("SELECT * FROM MovieViewings");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM MovieViewings WHERE Id = @Id",
            new { Id = id.ToString() });
        return result > 0;
    }
}
