using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class RowColumn : ValueOf<KeyValuePair<ulong, ulong>, RowColumn>
{
    protected override void Validate()
    {
        if (Value.Key == 0 || Value.Value == 0)
            throw new ArgumentException("Rows/Columns cannot be 0", nameof(Value));
    }
}