using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class MovieDescription : ValueOf<string, MovieDescription>
{
    private static string ErrorMessage { get; } = $"Movie description length cannot be longer than {Constants.MovieDescriptMaxLength} characters";

    protected override void Validate()
    {
        if (Constants.MovieDescriptMaxLength < Value.Length)
            throw new ArgumentException(ErrorMessage, nameof(MovieDescription));
    }
}
