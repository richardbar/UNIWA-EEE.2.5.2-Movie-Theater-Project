namespace MovieTheaterProject.API.Services.Reservation;

public interface IReservationService
{
    Task<bool> CreateAsync(Domain.Reservation reservation);

    Task<Domain.Reservation?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Reservation>> GetAllAsync();

    Task<bool> DeleteAsync(Guid id);
}
