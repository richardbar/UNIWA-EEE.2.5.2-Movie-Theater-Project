namespace MovieTheaterProject.API.Mapping;

public static class DtoToDomainMapper
{
    public static Reservation ToReservation(this ReservationDto reservationDto)
    {
        return new()
        {
            Id = ReservationId.From(Guid.Parse(reservationDto.Id)),
            MovieViewingId = MovieViewingId.From(Guid.Parse(reservationDto.MovieViewingId)),
            Row = RowsColumns.From(reservationDto.Row),
            Column = RowsColumns.From(reservationDto.Column),
            SeatsSelected = RowsColumns.From(reservationDto.SeatsSelected),
            PricePaid = Price.From(reservationDto.PricePaid)
        };
    }

    public static MovieViewing ToMovieViewing(this MovieViewingDto movieViewingDto)
    {
        return new()
        {
            Id = MovieViewingId.From(Guid.Parse(movieViewingDto.Id)),
            MovieId = MovieId.From(Guid.Parse(movieViewingDto.MovieId)),
            MovieTheaterId = MovieTheaterId.From(Guid.Parse(movieViewingDto.MovieTheaterId)),
            StartTime = Time.From(movieViewingDto.StartTime),
            Duration = Time.From(movieViewingDto.Duration)
        };
    }

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
