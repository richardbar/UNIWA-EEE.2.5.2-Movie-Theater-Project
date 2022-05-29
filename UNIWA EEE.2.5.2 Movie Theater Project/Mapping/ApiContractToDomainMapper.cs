using MovieTheaterProject.Contracts.Requests;
using MovieTheaterProject.Domain;
using MovieTheaterProject.Domain.Common;

namespace MovieTheaterProject.Mapping;

public static class ApiContractToDomainMapper
{
    public static Movie ToMovie(this CreateMovieRequest request)
    {
        return new Movie
        {
            Id = MovieId.From(Guid.NewGuid()),
            Name = MovieName.From(request.Name),
            Price = Price.From(request.Price),
            Duration = MovieDuration.From(TimeSpan.Parse(request.Duration))
        };
    }

    public static Movie ToMovie(this UpdateMovieRequest request)
    {
        return new Movie
        {
            Id = MovieId.From(request.Id),
            Name = MovieName.From(request.Name),
            Price = Price.From(request.Price),
            Duration = MovieDuration.From(TimeSpan.Parse(request.Duration))
        };
    }
}
