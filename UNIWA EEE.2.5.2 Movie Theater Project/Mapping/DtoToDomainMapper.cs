using MovieTheaterProject.Contracts.Data;
using MovieTheaterProject.Domain;
using MovieTheaterProject.Domain.Common;

namespace MovieTheaterProject.Mapping;

public static class DtoToDomainMapper
{
    public static Movie ToMovie(this MovieDto movieDto)
    {
        return new()
        {
            Id = MovieId.From(Guid.Parse(movieDto.Id)),
            Name = MovieName.From(movieDto.Name),
            Price = Price.From(movieDto.Price),
            Duration = MovieDuration.From(TimeSpan.Parse(movieDto.Duration))
        };
    }
}
