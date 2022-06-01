using MovieTheaterProject.Domain.Entities.Common;

namespace MovieTheaterProject.Domain.Entities;

public class MovieViewing
{
    private Time _startTime { get; set; } = default!;

    public MovieViewingId Id { get; init; } = default!;

    public MovieId MovieId { get; init; } = default!;

    public MovieTheaterId MovieTheaterId { get; init; } = default!;

    public Time StartTime
    { 
        get
        {
            return _startTime;
        }
        init
        {
            if (value.Value < Constants.MovieViewingsStart)
                throw new ArgumentException($"Movie viewing cannot start before {Math.Floor(Constants.MovieViewingsStart / (60f * 60f))}", nameof(StartTime.Value));
            if (Constants.MovieViewingsEnd < value.Value + Duration?.Value)
                throw new ArgumentException($"Movie viewing cannot end after {Math.Floor(Constants.MovieViewingsEnd / (60f * 60f))}", nameof(Constants.MovieViewingsEnd));
            _startTime = value;
        }
    }

    public Time Duration { get; set; } = default!;

    public MovieViewing()
    {
        
    }
}