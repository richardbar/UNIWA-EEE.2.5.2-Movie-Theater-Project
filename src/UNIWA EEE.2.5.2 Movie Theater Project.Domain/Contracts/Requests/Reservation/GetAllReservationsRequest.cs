namespace MovieTheaterProject.Domain.Contracts.Requests.Reservation;

public sealed class GetAllReservationsRequest
{
    public Guid? MovieViewingId { get; init; }
}
