namespace MovieTheaterProject.API.Contracts.Responses.Reservation;

public sealed class GetAllReservationsResponse
{
    public IEnumerable<ReservationResponse> Reservations { get; init; } = Enumerable.Empty<ReservationResponse>();
}
