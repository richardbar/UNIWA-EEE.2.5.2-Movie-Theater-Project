using Dapper;

namespace MovieTheaterProject.Database;

public sealed class DatabaseInitializer
{
    private IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Movies (
        Id CHAR(36) PRIMARY KEY, 
        Name TEXT NOT NULL,
        Price REAL NOT NULL,
        Duration TEXT NOT NULL)");
    }
}
