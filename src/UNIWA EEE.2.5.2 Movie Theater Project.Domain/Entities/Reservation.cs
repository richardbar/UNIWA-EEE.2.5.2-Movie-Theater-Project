using MovieTheaterProject.Domain.Entities.Common;

namespace MovieTheaterProject.Domain.Entities;

public class Reservation
{
    public ReservationId Id { get; init; } = default!;

    public MovieViewingId MovieViewingId { get; init; } = default!;

    public IEnumerable<RowColumn> SeatsSelected { get; init; } = default!;

    public Price PricePaid { get; set; } = default!;
}
