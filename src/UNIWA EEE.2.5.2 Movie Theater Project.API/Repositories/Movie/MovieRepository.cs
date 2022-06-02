using Dapper;

using MovieTheaterProject.API.Database;

namespace MovieTheaterProject.API.Repositories.Movie;

public sealed class MovieRepository : IMovieRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public MovieRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(MovieDto movie)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Movies (Id, Name, Description, Price, Duration) 
            VALUES (@Id, @Name, @Description, @Price, @Duration)",
            movie);
        return result > 0;
    }

    public async Task<MovieDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<MovieDto>(
            "SELECT * FROM Movies WHERE Id = @Id LIMIT 1",
            new { Id = id.ToString() });
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<MovieDto>("SELECT * FROM Movies");
    }

    public async Task<bool> UpdateAsync(MovieDto movie)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Movies SET Name = @Name, Price = @Price
                WHERE Id = @Id",
            movie);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM Movies WHERE Id = @Id",
            new { Id = id.ToString() });
        return result > 0;
    }
}
