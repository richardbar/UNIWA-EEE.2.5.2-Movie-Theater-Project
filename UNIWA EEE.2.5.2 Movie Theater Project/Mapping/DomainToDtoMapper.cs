using MovieTheaterProject.Contracts.Data;
using MovieTheaterProject.Domain;

namespace MovieTheaterProject.Mapping;

public static class DomainToDtoMapper
{
    public static MovieDto ToMovieDto(this Movie movie)
    {
        return new()
        {
            Id = movie.Id.Value.ToString(),
            Name = movie.Name.Value,
            Price = movie.Price.Value,
            Duration = movie.Duration.Value.ToString()
        };
    }
}
