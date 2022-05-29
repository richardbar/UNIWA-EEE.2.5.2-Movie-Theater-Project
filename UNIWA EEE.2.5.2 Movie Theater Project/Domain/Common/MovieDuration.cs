using ValueOf;

namespace MovieTheaterProject.Domain.Common;

public sealed class MovieDuration : ValueOf<long, MovieDuration>
{
    protected override void Validate()
    {
        if (Value < Constants.MovieMinimumDuration.TotalSeconds)
            throw new ArgumentException("Movie cannot be less than minimum screen time", nameof(MovieDuration));

        if (Constants.MovieMaximumDuration.TotalSeconds < Value)
            throw new ArgumentException("Movie cannot be more than maximum screen time", nameof(MovieDuration));
    }
}
