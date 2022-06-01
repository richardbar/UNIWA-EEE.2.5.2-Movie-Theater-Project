using System.Text.Json.Serialization;

namespace MovieTheaterProject.Domain.Contracts.Requests.MovieTheater;

public class UpdateMovieTheaterRequest
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    [JsonIgnore]
    public ushort Rows { get; set; } = default!;

    [JsonIgnore]
    public ushort Columns { get; set; } = default!;
}