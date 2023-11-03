namespace Mojito.DateTime;

public static class Timestamp
{
    /// <summary>
    /// Format the time character string in the format HH
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToHour(long timestamp)
    {
        return Parse(timestamp, "HH");
    }

    /// <summary>
    /// Format the time character string in the format mm
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToMinute(long timestamp)
    {
        return Parse(timestamp, "mm");
    }

    /// <summary>
    /// Format the time character string in the format ss
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToSecond(long timestamp)
    {
        return Parse(timestamp, "ss");
    }

    /// <summary>
    /// Format the time character string in the format HH:mm:ss
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToTime(long timestamp)
    {
        return Parse(timestamp, "HH:mm:ss");
    }

    /// <summary>
    /// Format the time character string in the format yyyy
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToYear(long timestamp)
    {
        return Parse(timestamp, "yyyy");
    }

    /// <summary>
    /// Format the time character string in the format MM
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToMonth(long timestamp)
    {
        return Parse(timestamp, "MM");
    }

    /// <summary>
    /// Format the time character string in the format dd
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToDay(long timestamp)
    {
        return Parse(timestamp, "dd");
    }

    /// <summary>
    /// Format the time character string in the format yyyy-MM-dd
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToDate(long timestamp)
    {
        return Parse(timestamp, "yyyy-MM-dd");
    }

    /// <summary>
    /// Format the time character string in the format yyyy-MM-dd HH:mm:ss
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static string ToDateTime(long timestamp)
    {
        return Parse(timestamp, "yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// Parse the Unix timestamp into a time string in the specified format
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <param name="format">Time format string</param>
    /// <returns></returns>
    public static string Parse(long timestamp, string format)
    {
        var startTime = TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local);
        var dateTime = startTime.AddSeconds(timestamp);
        return dateTime.ToString(format);
    }
}
