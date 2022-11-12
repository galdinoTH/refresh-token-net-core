namespace RefreshToken.Core.Extensions;

public static class DateExtensions
{
    public static double ConvertDateTimeToTimestamp(this DateTime value)
    {
        TimeSpan epoch = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
        return (double)epoch.TotalSeconds;
    }
}
