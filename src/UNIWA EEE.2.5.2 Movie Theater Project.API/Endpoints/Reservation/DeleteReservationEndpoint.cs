namespace MovieTheaterProject.API.Endpoints.Reservation;

[HttpDelete("api/reservations/{id:guid}"), AllowAnonymous]
public sealed class DeleteReservationEndpoint : Endpoint<DeleteReservationRequest>
{
    private readonly IReservationService _reservationService;

    public DeleteReservationEndpoint(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task HandleAsync(DeleteReservationRequest req, CancellationToken ct)
    {
        var deleted = await _reservationService.DeleteAsync(req.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
