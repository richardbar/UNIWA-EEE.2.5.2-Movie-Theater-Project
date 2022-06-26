using System.Net.Http.Json;
using MovieTheaterProject.Domain.Contracts.Responses.Reservation;


namespace MovieTheaterProject.UI.Utilities.ReservationManager;

public sealed class ReservationManager : IReservationManager
{
    private static readonly string s_apiURL = "api/reservations";
    private HttpClient _http;

    public ReservationManager(HttpClient http)
    {
        _http = http;
    }

    public async Task<ReservationResponse?> GetReservationById(Guid reservationId) =>
        await _http.GetFromJsonAsync<ReservationResponse>($"{s_apiURL}/{reservationId}");

    public async Task<ReservationResponse[]?> GetReservationsByMovieViewingId(Guid movieViewingId)
    {
        var response = await _http.GetFromJsonAsync<GetAllReservationsResponse>(
            $"{s_apiURL}?MovieViewingId={movieViewingId}");

        if (response is null)
            return default!;

        var reservations = response.Reservations.ToArray();

        return reservations;
    }

    public async Task<ReservationResponse[]?> GetAllReservations()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<GetAllReservationsResponse>(s_apiURL);

            if (response is null)
                return null;

            return response.Reservations.ToArray();
        }
        catch
        {
            return null;
        }
    }
}