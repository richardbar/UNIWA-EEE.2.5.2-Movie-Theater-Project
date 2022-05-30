using MovieTheaterProject.API.Contracts.Data;
using MovieTheaterProject.API.Domain;
using MovieTheaterProject.API.Domain.Common;

namespace MovieTheaterProject.API.Mapping;

public static class DtoToDomainMapper
{
    public static MovieTheater ToMovieTheater(this MovieTheaterDto movieTheaterDto)
    {
        return new()
        {
            Id = MovieTheaterId.From(Guid.Parse(movieTheaterDto.Id)),
            Name = Name.From(movieTheaterDto.Name),
            Rows = RowsColumns.From(movieTheaterDto.Rows),
            Columns = RowsColumns.From(movieTheaterDto.Columns)
        };
    }

    public static Movie ToMovie(this MovieDto movieDto)
    {
        return new()
        {
            Id = MovieId.From(Guid.Parse(movieDto.Id)),
            Name = Name.From(movieDto.Name),
            Price = Price.From(movieDto.Price),
            Duration = MovieDuration.From(movieDto.Duration)
        };
    }
}
