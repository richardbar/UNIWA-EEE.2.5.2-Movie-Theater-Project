namespace MovieTheaterProject.API.Repositories.Reservation;

public interface IReservationRepository
{
    Task<bool> CreateAsync(ReservationDto reservation);

    Task<ReservationDto?> GetAsync(Guid id);

    Task<IEnumerable<ReservationDto>> GetAllAsync();

    Task<IEnumerable<ReservationDto>> GetAsyncByMovieViewingId(Guid id);

    Task<bool> DeleteAsync(Guid id);
}
