using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Services.Reservation;
using MovieTheaterProject.API.Contracts.Requests.Reservation;
using MovieTheaterProject.API.Contracts.Responses.Reservation;

namespace MovieTheaterProject.API.Endpoints.Reservation;

[HttpGet("/api/reservations/{id:guid}"), AllowAnonymous]
public sealed class GetReservationEndpoint : Endpoint<GetReservationRequest, ReservationResponse>
{
    private readonly IReservationService _reservationService;

    public GetReservationEndpoint(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task HandleAsync(GetReservationRequest req, CancellationToken ct)
    {
        var reservation = await _reservationService.GetAsync(req.Id);

        if (reservation is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var reservationResponse = reservation.ToReservationResponse();
        await SendOkAsync(reservationResponse, ct);
    }
}
