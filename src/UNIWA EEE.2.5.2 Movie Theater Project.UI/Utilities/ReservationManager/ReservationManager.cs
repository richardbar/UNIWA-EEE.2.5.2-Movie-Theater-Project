using System.Net.Http.Json;
using MovieTheaterProject.Domain.Contracts.Responses.Reservation;


namespace MovieTheaterProject.UI.Utilities.ReservationManager;

public sealed class ReservationManager : IReservationManager
{
    private HttpClient _http;

    public ReservationManager(HttpClient http)
    {
        _http = http;
    }

    public async Task<ReservationResponse?> GetReservationById(Guid reservationId) =>
        await _http.GetFromJsonAsync<ReservationResponse>($"api/reservations/{reservationId}");

    public async Task<ReservationResponse[]?> GetReservationsByMovieViewingId(Guid movieViewingId)
    {
        var response = await _http.GetFromJsonAsync<GetAllReservationsResponse>(
            $"api/reservations?MovieViewingId={movieViewingId}");

        if (response is null)
            return default!;

        var reservations = response.Reservations.ToArray();

        return reservations;
    }
}
