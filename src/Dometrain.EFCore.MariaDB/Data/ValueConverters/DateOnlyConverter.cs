using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dometrain.EFCore.MariaDB.Data.ValueConverters;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime)
        )
    { }
}