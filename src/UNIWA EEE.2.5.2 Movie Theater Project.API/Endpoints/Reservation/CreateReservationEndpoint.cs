namespace MovieTheaterProject.API.Endpoints.Reservation;

[HttpPost("/api/reservations"), AllowAnonymous]
public sealed class CreateReservationEndpoint : Endpoint<CreateReservationRequest, ReservationResponse>
{
    private readonly IReservationService _reservationService;
    private readonly IMovieViewingService _movieViewingService;
    private readonly IMovieService _movieService;

    public CreateReservationEndpoint(
        IReservationService reservationService,
        IMovieViewingService movieViewingService,
        IMovieService movieService)
    {
        _reservationService = reservationService;
        _movieViewingService = movieViewingService;
        _movieService = movieService;
    }

    public override async Task HandleAsync(CreateReservationRequest req, CancellationToken ct)
    {
        var reservation = req.ToReservation();

        var movieViewing = await _movieViewingService.GetAsync(reservation.MovieViewingId.Value);
        var movie = await _movieService.GetAsync(movieViewing!.MovieId.Value);

        reservation.PricePaid = Price.From(reservation.SeatsSelected.Value * movie!.Price.Value);

        await _reservationService.CreateAsync(reservation);

        var reservationResponse = reservation.ToReservationResponse();
        await SendCreatedAtAsync<GetReservationEndpoint>(
            new { Id = reservation.Id.Value }, reservationResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
