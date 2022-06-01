namespace MovieTheaterProject.API.Contracts.Responses.Reservation;

public sealed class ReservationResponse
{
    public Guid Id { get; init; } = default!;

    public Guid MovieViewingId { get; init; } = default!;

    public ushort Row { get; init; } = default!;

    public ushort Column { get; init; } = default!;

    public ushort SeatsSelected { get; init; } = default!;
}
