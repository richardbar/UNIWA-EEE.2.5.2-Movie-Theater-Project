using MovieTheaterProject.Domain.Contracts.Responses.Reservation;

namespace MovieTheaterProject.UI.Utilities.ReservationManager;

public interface IReservationManager
{
    public Task<ReservationResponse?> GetReservationById(Guid reservationId);

    public Task<ReservationResponse[]?> GetReservationsByMovieViewingId(Guid movieViewingId);
}
