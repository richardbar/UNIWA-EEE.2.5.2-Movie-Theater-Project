namespace MovieTheaterProject.API.Mapping;

public static class DomainToDtoMapper
{
    public static ReservationDto ToReservationDto(this Reservation reservation)
    {
        return new()
        {
            Id = reservation.Id.Value.ToString(),
            MovieViewingId = reservation.MovieViewingId.Value.ToString(),
            SeatsSelected = string.Join("--", reservation.SeatsSelected
                .Select(seatSelected =>
                {
                    return seatSelected.Value.Key.ToString() + '-' + seatSelected.Value.Value.ToString();
                })),
            PricePaid = reservation.PricePaid.Value
        };
    }

    public static MovieViewingDto ToMovieViewingDto(this MovieViewing movieViewing)
    {
        return new()
        {
            Id = movieViewing.Id.Value.ToString(),
            MovieId = movieViewing.MovieId.Value.ToString(),
            MovieTheaterId = movieViewing.MovieTheaterId.Value.ToString(),
            StartTime = movieViewing.StartTime.Value,
            Duration = movieViewing.Duration.Value,
        };
    }

    public static MovieTheaterDto ToMovieTheaterDto(this MovieTheater movieTheater)
    {
        return new()
        {
            Id = movieTheater.Id.Value.ToString(),
            Name = movieTheater.Name.Value,
            Rows = movieTheater.Rows.Value,
            Columns = movieTheater.Columns.Value
        };
    }

    public static MovieDto ToMovieDto(this Movie movie)
    {
        return new()
        {
            Id = movie.Id.Value.ToString(),
            Name = movie.Name.Value,
            Description = movie.Description.Value,
            Price = movie.Price.Value,
            Duration = movie.Duration.Value
        };
    }
}
