using MovieTheaterProject.API.Domain.Common;

namespace MovieTheaterProject.API.Domain;

public class Movie
{
    public MovieId Id { get; init; } = default!;

    public Name Name { get; init; } = default!;

    public Price Price { get; init; } = default!;

    public MovieDuration Duration { get; init; } = default!;
}
