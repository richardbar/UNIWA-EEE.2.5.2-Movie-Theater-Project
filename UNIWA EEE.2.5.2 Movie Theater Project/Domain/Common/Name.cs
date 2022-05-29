using ValueOf;

namespace MovieTheaterProject.Domain.Common;

public sealed class Name : ValueOf<string, Name>
{
    protected override void Validate()
    {
        if (Value is null)
            throw new ArgumentNullException("Name cannot be null", nameof(Name));

        if (string.IsNullOrEmpty(Value))
            throw new ArgumentException("Name cannot be empty", nameof(Name));
        
        if (string.IsNullOrWhiteSpace(Value))
            throw new ArgumentException("Name cannot be whitespaces", nameof(Name));
        
        if (64 < Value.Length)
            throw new ArgumentException("Name cannot be longer that 64 characters", nameof(Name));
    }
}
