namespace MovieTheaterProject.Domain.Contracts.Data;

public class ReservationDto
{
    public string Id { get; init; } = default!;

    public string MovieViewingId { get; init; } = default!;

    public string SeatsSelected { get; init; } = default;

    public float PricePaid { get; init; } = default!;
}
