using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class MovieId : ValueOf<Guid, MovieId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
            throw new ArgumentException("Movie Id cannot be empty", nameof(MovieId));
    }
}
