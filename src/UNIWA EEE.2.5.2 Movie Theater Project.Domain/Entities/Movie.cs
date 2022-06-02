using MovieTheaterProject.Domain.Entities.Common;

namespace MovieTheaterProject.Domain.Entities;

public class Movie
{
    public MovieId Id { get; init; } = default!;

    public Name Name { get; init; } = default!;

    public MovieDescription Description { get; init; } = default!;

    public Price Price { get; init; } = default!;

    public MovieDuration Duration { get; init; } = default!;
}
