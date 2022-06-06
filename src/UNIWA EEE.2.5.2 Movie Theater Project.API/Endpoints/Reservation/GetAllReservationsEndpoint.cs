namespace MovieTheaterProject.API.Endpoints.Reservation;

[HttpGet("/api/reservations"), AllowAnonymous]
public sealed class GetAllReservationsEndpoint : Endpoint<GetAllReservationsRequest, GetAllReservationsResponse>
{
    private readonly IReservationService _reservationService;

    public GetAllReservationsEndpoint(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task HandleAsync(GetAllReservationsRequest request, CancellationToken ct)
    {
        IEnumerable<Domain.Entities.Reservation> reservations = request.MovieViewingId switch
        {
            null => await _reservationService.GetAllAsync(),
            _ => await _reservationService.GetAllByMovieViewingIdAsync((Guid)request.MovieViewingId)
        };
            
        var reservationsResponse = reservations.ToReservationResponse();
        await SendOkAsync(reservationsResponse);
    }
}
