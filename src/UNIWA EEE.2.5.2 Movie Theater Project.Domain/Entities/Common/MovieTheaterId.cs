using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class MovieTheaterId : ValueOf<Guid, MovieTheaterId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
            throw new ArgumentException("Movie Theater Id cannot be empty", nameof(MovieId));
    }
}
