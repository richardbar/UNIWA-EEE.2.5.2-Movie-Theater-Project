using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Domain;
using MovieTheaterProject.Domain.Common;

namespace MovieTheaterProject.Mapping;

public static class ApiContractToDomainMapper
{
    public static MovieTheater ToMovieTheater(this CreateMovieTheaterRequest request)
    {
        return new()
        {
            Id = MovieTheaterId.From(Guid.NewGuid()),
            Name = Name.From(request.Name),
            Rows = RowsColumns.From(request.Rows),
            Columns = RowsColumns.From(request.Columns)
        };
    }

    public static MovieTheater ToMovieTheater(this UpdateMovieTheaterRequest request)
    {
        return new()
        {
            Id = MovieTheaterId.From(request.Id),
            Name = Name.From(request.Name),
            Rows = RowsColumns.From(request.Rows),
            Columns = RowsColumns.From(request.Columns)
        };
    }

    public static Movie ToMovie(this CreateMovieRequest request)
    {
        return new()
        {
            Id = MovieId.From(Guid.NewGuid()),
            Name = Name.From(request.Name),
            Price = Price.From(request.Price),
            Duration = MovieDuration.From(request.Duration)
        };
    }

    public static Movie ToMovie(this UpdateMovieRequest request)
    {
        return new()
        {
            Id = MovieId.From(request.Id),
            Name = Name.From(request.Name),
            Price = Price.From(request.Price),
            Duration = MovieDuration.From(request.Duration)
        };
    }
}
