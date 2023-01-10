using Buber.Application.Common.Interfaces.Services;

namespace Buber.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}