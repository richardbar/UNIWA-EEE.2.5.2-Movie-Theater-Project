using Microsoft.AspNetCore.Authorization;
using FastEndpoints;

using MovieTheaterProject.API.Contracts.Responses.Reservation;
using MovieTheaterProject.API.Services.Reservation;
using MovieTheaterProject.API.Mapping;

namespace MovieTheaterProject.API.Endpoints.Reservation;

[HttpGet("/api/reservations"), AllowAnonymous]
public sealed class GetAllReservationsEndpoint : EndpointWithoutRequest<GetAllReservationsResponse>
{
    private readonly IReservationService _reservationService;

    public GetAllReservationsEndpoint(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var reservations = await _reservationService.GetAllAsync();
        var reservationsResponse = reservations.ToReservationResponse();
        await SendOkAsync(reservationsResponse);
    }
}
