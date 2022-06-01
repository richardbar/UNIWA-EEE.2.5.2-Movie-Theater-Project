using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class MovieViewingId : ValueOf<Guid, MovieViewingId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
            throw new ArgumentException("Movie Viewing Id cannot be empty", nameof(MovieId));
    }
}
