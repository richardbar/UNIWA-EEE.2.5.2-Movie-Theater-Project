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
        Duration INTEGER(8) NOT NULL)");
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS MovieTheaters (
        Id CHAR(36) PRIMARY KEY, 
        Name TEXT NOT NULL,
        Rows INT NOT NULL,
        Columns INT NOT NULL)");
    }
}
