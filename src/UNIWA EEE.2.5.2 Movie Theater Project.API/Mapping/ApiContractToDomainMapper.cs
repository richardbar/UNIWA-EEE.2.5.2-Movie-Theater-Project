namespace MovieTheaterProject.API.Mapping;

public static class ApiContractToDomainMapper
{
    public static Reservation ToReservation(this CreateReservationRequest request)
    {
        return new()
        {
            Id = ReservationId.From(Guid.NewGuid()),
            MovieViewingId = MovieViewingId.From(Guid.Parse(request.MovieViewingId)),
            SeatsSelected = request.SeatsSelected.Select(seatSelected =>
                RowColumn.From(new KeyValuePair<ulong, ulong>(ulong.Parse(seatSelected.Split('-')[0]), ulong.Parse(seatSelected.Split('-')[1]))))
        };
    }

    public static MovieViewing ToMovieViewing(this CreateMovieViewingRequest request)
    {
        return new()
        {
            Id = MovieViewingId.From(Guid.NewGuid()),
            MovieId = MovieId.From(Guid.Parse(request.MovieId)),
            MovieTheaterId = MovieTheaterId.From(Guid.Parse(request.MovieTheaterId)),
            StartTime = Time.From(request.StartTime)
        };
    }

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
            Description = MovieDescription.From(request.Description),
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
            Description = MovieDescription.From(request.Description),
            Price = Price.From(request.Price),
            Duration = MovieDuration.From(request.Duration)
        };
    }
}
