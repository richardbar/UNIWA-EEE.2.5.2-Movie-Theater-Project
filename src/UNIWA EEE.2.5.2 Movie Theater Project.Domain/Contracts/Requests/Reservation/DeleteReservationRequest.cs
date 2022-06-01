namespace MovieTheaterProject.Domain.Contracts.Requests.Reservation;

public sealed class DeleteReservationRequest
{
    public Guid Id { get; init; }
}
