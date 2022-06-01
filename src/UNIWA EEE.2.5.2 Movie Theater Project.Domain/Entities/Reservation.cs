using MovieTheaterProject.Domain.Entities.Common;

namespace MovieTheaterProject.Domain.Entities;

public class Reservation
{
    public ReservationId Id { get; init; } = default!;

    public MovieViewingId MovieViewingId { get; init; } = default!;

    public RowsColumns Row { get; init; } = default!;

    public RowsColumns Column { get; init; } = default!;

    public RowsColumns SeatsSelected { get; init; } = default!;

    public Price PricePaid { get; set; } = default!;
}
