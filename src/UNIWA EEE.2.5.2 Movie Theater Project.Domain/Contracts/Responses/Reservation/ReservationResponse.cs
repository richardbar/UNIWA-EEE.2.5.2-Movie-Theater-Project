namespace MovieTheaterProject.Domain.Contracts.Responses.Reservation;

public sealed class ReservationResponse
{
    public Guid Id { get; init; } = default!;

    public Guid MovieViewingId { get; init; } = default!;

    public IEnumerable<string> SeatsSelected { get; init; } = default!;

    public float PricePaid { get; init; } = default!;
}
