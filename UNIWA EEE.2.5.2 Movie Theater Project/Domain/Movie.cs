using MovieTheaterProject.Domain.Common;

namespace MovieTheaterProject.Domain;

public class Movie
{
    public MovieId Id { get; init; } = MovieId.From(Guid.NewGuid());

    public MovieName Name { get; init; } = MovieName.From(default!);

    public Price Price { get; init; } = Price.From(.0f);

    public MovieDuration Duration { get; init; } = MovieDuration.From(Constants.MovieMinimumDuration);
}
