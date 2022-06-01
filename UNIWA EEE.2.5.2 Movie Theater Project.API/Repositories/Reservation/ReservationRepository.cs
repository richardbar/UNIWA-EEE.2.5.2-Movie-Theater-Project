using Dapper;
using MovieTheaterProject.API.Contracts.Data;
using MovieTheaterProject.API.Database;

namespace MovieTheaterProject.API.Repositories.Reservation;

public sealed class ReservationRepository : IReservationRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ReservationRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(ReservationDto reservation)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Reservations (Id, MovieViewingId, Row, Column, SeatsSelected) 
            VALUES (@Id, @MovieViewingId, @Row, @Column, @SeatsSelected)",
            reservation);
        return result > 0;
    }

    public async Task<ReservationDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<ReservationDto>(
            "SELECT * FROM Reservations WHERE Id = @Id LIMIT 1",
            new { Id = id.ToString() });
    }

    public async Task<IEnumerable<ReservationDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<ReservationDto>("SELECT * FROM Reservations");
    }

    public async Task<IEnumerable<ReservationDto>> GetAsyncByMovieViewingId(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<ReservationDto>("SELECT * FROM Reservations WHERE MovieViewingId = @Id",
            new { Id = id.ToString() });
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM Reservations WHERE Id = @Id",
            new { Id = id.ToString() });
        return result > 0;
    }
}
