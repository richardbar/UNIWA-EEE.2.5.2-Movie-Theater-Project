using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.API.Mapping;
using MovieTheaterProject.API.Contracts.Requests.Reservation;
using MovieTheaterProject.API.Contracts.Responses.Reservation;
using MovieTheaterProject.API.Services.MovieViewing;
using MovieTheaterProject.API.Services.Reservation;
using MovieTheaterProject.API.Domain.Common;

namespace MovieTheaterProject.API.Endpoints.Reservation;

[HttpPost("/api/reservations"), AllowAnonymous]
public sealed class CreateReservationEndpoint : Endpoint<CreateReservationRequest, ReservationResponse>
{
    private readonly IReservationService _reservationService;

    public CreateReservationEndpoint(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task HandleAsync(CreateReservationRequest req, CancellationToken ct)
    {
        var reservation = req.ToReservation();
        
        await _reservationService.CreateAsync(reservation);

        var reservationResponse = reservation.ToReservationResponse();
        await SendCreatedAtAsync<GetReservationEndpoint>(
            new { Id = reservation.Id.Value }, reservationResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
