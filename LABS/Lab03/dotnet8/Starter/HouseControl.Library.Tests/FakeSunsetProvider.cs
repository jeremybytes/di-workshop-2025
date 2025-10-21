using HouseControl.Sunset;

namespace HouseControl.Library.Tests;

public class FakeSunsetProvider : ISunsetProvider
{
    private TimeSpan timeZoneOffset = new(-2, 0, 0);

    public DateTimeOffset GetSunrise(DateTime date)
    {
        return new DateTimeOffset(2025, 11, 02, 06, 15, 55, timeZoneOffset);
    }

    public DateTimeOffset GetSunset(DateTime date)
    {
        return new DateTimeOffset(2025, 11, 02, 18, 15, 55, timeZoneOffset);
    }
}
