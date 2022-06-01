namespace MovieTheaterProject.API.Services.Reservation;

public sealed class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMovieViewingRepository _movieViewingRepository;

    public ReservationService(
        IReservationRepository reservationRepository,
        IMovieViewingRepository movieViewingRepository)
    {
        _reservationRepository = reservationRepository;
        _movieViewingRepository = movieViewingRepository;
    }

    public async Task<bool> CreateAsync(Domain.Entities.Reservation reservation)
    {
        var movieViewingFound = (await _movieViewingRepository.GetAsync(reservation.MovieViewingId.Value)) is not null;
        if (!movieViewingFound)
        {
            var message = $"A movie viewing with the id {reservation.MovieViewingId.Value} was not found";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Reservation), message)
            });
        }

        var reservationDto = reservation.ToReservationDto();
        return await _reservationRepository.CreateAsync(reservationDto);
    }

    public async Task<Domain.Entities.Reservation?> GetAsync(Guid id)
    {
        var reservationDto = await _reservationRepository.GetAsync(id);
        return reservationDto?.ToReservation();
    }

    public async Task<IEnumerable<Domain.Entities.Reservation>> GetAllAsync()
    {
        var reservationDtos = await _reservationRepository.GetAllAsync();
        return reservationDtos.Select(reservationDto => reservationDto.ToReservation());
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _reservationRepository.DeleteAsync(id);
    }
}
