namespace MovieTheaterProject.Domain.Contracts.Requests.Reservation;

public class CreateReservationRequest
{
    public string MovieViewingId { get; init; } = default!;

    public ICollection<string> SeatsSelected { get; init; } = default!;
}
