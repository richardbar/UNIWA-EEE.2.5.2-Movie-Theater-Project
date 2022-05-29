using ValueOf;

namespace MovieTheaterProject.Domain.Common;

public sealed class MovieName : ValueOf<string, MovieName>
{
    protected override void Validate()
    {
        if (Value is null)
            throw new ArgumentNullException("Movie Name cannot be null", nameof(MovieName));

        if (string.IsNullOrEmpty(Value))
            throw new ArgumentException("Movie Name cannot be empty", nameof(MovieName));
        
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException("Movie Name cannot be whitespaces", nameof(MovieName));
        
        if (64 < Value.Length)
            throw new ArgumentException("Movie Name cannot be longer that 64 characters", nameof(MovieName));
    }
}
