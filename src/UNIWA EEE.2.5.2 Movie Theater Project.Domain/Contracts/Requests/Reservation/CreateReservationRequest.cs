namespace MovieTheaterProject.Domain.Contracts.Requests.Reservation;

public class CreateReservationRequest
{
    public string MovieViewingId { get; init; } = default!;

    public ushort Row { get; init; } = default!;

    public ushort Column { get; init; } = default!;

    public ushort SeatsSelected { get; init; } = default!;
}
