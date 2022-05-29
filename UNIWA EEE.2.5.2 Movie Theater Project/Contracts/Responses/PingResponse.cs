namespace MovieTheaterProject.Contracts.Responses;

public sealed class PingResponse
{
    public Guid RequestId { get; init; } = Guid.NewGuid();

    public DateTime DateTime { get; init; } = DateTime.Now;
}
