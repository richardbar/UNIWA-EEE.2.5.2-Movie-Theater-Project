using Dapper;

using MovieTheaterProject.Contracts.Data;
using MovieTheaterProject.Database;

namespace MovieTheaterProject.Repositories;

public sealed class MovieTheaterRepository : IMovieTheaterRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public MovieTheaterRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(MovieTheaterDto movieTheater)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO MovieTheaters (Id, Name, Rows, Columns) 
            VALUES (@Id, @Name, @Rows, @Columns)",
            movieTheater);
        return result > 0;
    }

    public async Task<MovieTheaterDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<MovieTheaterDto>(
            "SELECT * FROM MovieTheaters WHERE Id = @Id LIMIT 1",
            new { Id = id.ToString() });
    }

    public async Task<IEnumerable<MovieTheaterDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<MovieTheaterDto>("SELECT * FROM MovieTheaters");
    }

    public async Task<bool> UpdateAsync(MovieTheaterDto movieTheater)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE MovieTheaters SET Name = @Name, Rows = @Rows, Columns = @Columns
                WHERE Id = @Id",
            movieTheater);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM MovieTheaters WHERE Id = @Id",
            new { Id = id.ToString() });
        return result > 0;
    }
}
