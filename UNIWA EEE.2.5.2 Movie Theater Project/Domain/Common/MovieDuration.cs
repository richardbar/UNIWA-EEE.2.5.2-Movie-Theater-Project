using ValueOf;

namespace MovieTheaterProject.Domain.Common;

public sealed class MovieDuration : ValueOf<TimeSpan, MovieDuration>
{
    protected override void Validate()
    {
        if (Constants.MovieMinimumDuration < Value)
            throw new ArgumentException("Movie cannot be less than minimum screen time", nameof(MovieDuration));

        if (Value < Constants.MovieMaximumDuration)
            throw new ArgumentException("Movie cannot be more than maximum screen time", nameof(MovieDuration));
    }
}
