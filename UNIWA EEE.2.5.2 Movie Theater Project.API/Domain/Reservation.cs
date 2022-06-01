using MovieTheaterProject.API.Domain.Common;

namespace MovieTheaterProject.API.Domain;

public class Reservation
{
    public ReservationId Id { get; init; } = default!;

    public MovieViewingId MovieViewingId { get; init; } = default!;

    public RowsColumns Row { get; init; } = default!;

    public RowsColumns Column { get; init; } = default!;

    public RowsColumns SeatsSelected { get; init; } = default!;
}
