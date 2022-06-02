using System.Text.Json.Serialization;

namespace MovieTheaterProject.Domain.Contracts.Requests.Movie;

public class UpdateMovieRequest
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public string Description { get; init; } = default!;

    public float Price { get; init; } = .0f;

    [JsonIgnore]
    public long Duration { get; set; } = default!;
}