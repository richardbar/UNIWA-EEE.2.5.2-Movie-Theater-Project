namespace MovieTheaterProject.Domain;

public static class Constants
{
    public static TimeSpan MovieMinimumDuration { get; } = new(1, 0, 0);

    public static TimeSpan MovieMaximumDuration { get; } = new(1, 30, 0);

    public static long MovieViewingsStart { get; } = 18 * 60 * 60;
    
    public static long MovieViewingsEnd { get; } = 26 * 60 * 60;

    public static ushort MovieNameMaxLength { get; } = 64;

    public static ushort MovieDescriptMaxLength { get; } = 4096;
}
