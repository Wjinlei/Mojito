namespace Mojito.DateTime;

public static class Timestamp
{
    /// <summary>
    /// Format the time character string in the format HH
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToHour(long timestamp)
    {
        return Parse(timestamp, "HH");
    }

    /// <summary>
    /// Format the time character string in the format mm
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToMinute(long timestamp)
    {
        return Parse(timestamp, "mm");
    }

    /// <summary>
    /// Format the time character string in the format ss
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToSecond(long timestamp)
    {
        return Parse(timestamp, "ss");
    }

    /// <summary>
    /// Format the time character string in the format HH:mm:ss
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToTime(long timestamp)
    {
        return Parse(timestamp, "HH:mm:ss");
    }

    /// <summary>
    /// Format the time character string in the format yyyy
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToYear(long timestamp)
    {
        return Parse(timestamp, "yyyy");
    }

    /// <summary>
    /// Format the time character string in the format MM
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToMonth(long timestamp)
    {
        return Parse(timestamp, "MM");
    }

    /// <summary>
    /// Format the time character string in the format dd
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToDay(long timestamp)
    {
        return Parse(timestamp, "dd");
    }

    /// <summary>
    /// Format the time character string in the format yyyy-MM-dd
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToDate(long timestamp)
    {
        return Parse(timestamp, "yyyy-MM-dd");
    }

    /// <summary>
    /// Format the time character string in the format yyyy-MM-dd HH:mm:ss
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <returns></returns>
    public static Result<string> ToDateTime(long timestamp)
    {
        return Parse(timestamp, "yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// Parse the Unix timestamp into a time string in the specified format
    /// </summary>
    /// <param name="timestamp">Unix timestamp</param>
    /// <param name="format">Time format string</param>
    /// <returns></returns>
    public static Result<string> Parse(long timestamp, string format)
    {
        try
        {
            var startTime = TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local);
            var dateTime = startTime.AddSeconds(timestamp);
            var time = dateTime.ToString(format);
            return Result<string>.Ok(time);
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex);
        }
    }
}
