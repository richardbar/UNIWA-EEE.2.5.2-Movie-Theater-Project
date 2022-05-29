using MovieTheaterProject.Domain.Common;

namespace MovieTheaterProject.Domain;

public class MovieTheater
{
    public MovieTheaterId Id { get; init; } = default!;

    public Name Name { get; init; } = default!;

    public RowsColumns Rows { get; init; } = default!;

    public RowsColumns Columns { get; init; } = default!;
}
