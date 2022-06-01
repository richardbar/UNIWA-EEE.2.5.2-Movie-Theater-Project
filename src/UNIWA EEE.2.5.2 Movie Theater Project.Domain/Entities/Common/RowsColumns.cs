using ValueOf;

namespace MovieTheaterProject.Domain.Entities.Common;

public sealed class RowsColumns : ValueOf<ushort, RowsColumns>
{
    protected override void Validate()
    {
        if (Value == 0)
            throw new ArgumentException("Rows/Columns cannot be 0", nameof(Value));
    }
}
