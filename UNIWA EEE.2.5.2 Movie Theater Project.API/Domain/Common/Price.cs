using ValueOf;

namespace MovieTheaterProject.API.Domain.Common;

public sealed class Price : ValueOf<float, Price>
{
    protected override void Validate()
    {
        if (Value < .0f)
            throw new ArgumentException("Price cannot be negative", nameof(Price));
    }
}