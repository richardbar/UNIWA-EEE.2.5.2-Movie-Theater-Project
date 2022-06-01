using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class ReservationId : ValueOf<Guid, ReservationId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
            throw new ArgumentException("Reservation Id cannot be empty", nameof(MovieId));
    }
}
