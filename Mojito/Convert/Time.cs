namespace Mojito.Convert;

public static class Time
{
    /// <summary>
    /// Parse the Unix timestamp into a time string in the specified format
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <param name="format">Time format string</param>
    /// <returns></returns>
    public static string Format(long timestamp, string format)
    {
        var startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local);
        var dateTime = startTime.AddSeconds(timestamp);
        return dateTime.ToString(format);
    }

    /// <summary>
    /// Parse the time string as a timestamp
    /// </summary>
    /// <param name="format">Time string</param>
    /// <returns></returns>
    public static long ToTimestamp(string format)
    {
        var dateTime = DateTime.Parse(format);
        return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
    }
}
