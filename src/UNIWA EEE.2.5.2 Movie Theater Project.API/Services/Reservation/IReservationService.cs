namespace MovieTheaterProject.API.Services.Reservation;

public interface IReservationService
{
    Task<bool> CreateAsync(Domain.Entities.Reservation reservation);

    Task<Domain.Entities.Reservation?> GetAsync(Guid id);

    Task<IEnumerable<Domain.Entities.Reservation>> GetAllAsync();

    Task<bool> DeleteAsync(Guid id);
}
