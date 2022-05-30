namespace MovieTheaterProject.API;

public static class Constants
{
    public static TimeSpan MovieMinimumDuration { get; } = new(1, 0, 0);

    public static TimeSpan MovieMaximumDuration { get; } = new(1, 30, 0);
}
