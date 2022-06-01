using Dapper;

namespace MovieTheaterProject.API.Database;

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
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS MovieViewings (
        Id CHAR(36) PRIMARY KEY, 
        MovieId TEXT(36) NOT NULL,
        MovieTheaterId TEXT(36) NOT NULL,
        StartTime INT(8) NOT NULL,
        Duration INT(8) NOT NULL)");
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Reservations (
        Id CHAR(36) PRIMARY KEY,
        MovieViewingId CHAR(36) NOT NULL,
        Row INT NOT NULL,
        Column INT NOT NULL,
        SeatsSelected INT NOT NULL,
        PricePaid REAL NOT NULL)");
    }
}
