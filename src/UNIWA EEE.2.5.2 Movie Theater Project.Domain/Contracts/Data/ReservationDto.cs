namespace MovieTheaterProject.Domain.Contracts.Data;

public class ReservationDto
{
    public string Id { get; init; } = default!;

    public string MovieViewingId { get; init; } = default!;

    public ushort Row { get; init; } = default!;

    public ushort Column { get; init; } = default!;

    public ushort SeatsSelected { get; init; } = default;

    public float PricePaid { get; init; } = default!;
}
