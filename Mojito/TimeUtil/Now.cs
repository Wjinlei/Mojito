namespace Mojito.TimeUtil;

public static class Now
{
    /// <summary>
    /// Gets a string representation of the number of hours in the current time
    /// </summary>
    /// <returns>Returns a time string in HH format</returns>
    public static string GetHour()
    {
        return DateTime.Now.ToString("HH");
    }

    /// <summary>
    /// Gets a string representation of the number of minutes in the current time
    /// </summary>
    /// <returns>Return a time string in mm format</returns>
    public static string GetMinute()
    {
        return DateTime.Now.ToString("mm");
    }

    /// <summary>
    /// Gets a string representation of the number of seconds of the current time
    /// </summary>
    /// <returns>Returns a time string in ss format</returns>
    public static string GetSecond()
    {
        return DateTime.Now.ToString("ss");
    }

    /// <summary>
    /// Gets a string representation of the current time
    /// </summary>
    /// <returns>The time string is in HH:mm:ss format</returns>
    public static string GetTime()
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }

    /// <summary>
    /// Gets a string representation of the year of the current time
    /// </summary>
    /// <returns>Returns a time string in yyyy format</returns>
    public static string GetYear()
    {
        return DateTime.Now.ToString("yyyy");
    }

    /// <summary>
    /// Gets a string representation of the month of the current time
    /// </summary>
    /// <returns>Return a time string in MM format</returns>
    public static string GetMonth()
    {
        return DateTime.Now.ToString("MM");
    }

    /// <summary>
    /// Gets a string representation of the number of days in the current time
    /// </summary>
    /// <returns>Return a time string in dd format</returns>
    public static string GetDay()
    {
        return DateTime.Now.ToString("dd");
    }

    /// <summary>
    /// Gets a string representation of the current date
    /// </summary>
    /// <returns>The time string is in the format yyyy-MM-dd</returns>
    public static string GetDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Gets a string representation of the current date and time
    /// </summary>
    /// <returns>The value is a time string in the format yyyy-MM-dd HH:mm:ss</returns>
    public static string GetDateTime()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// Returns the current time string formatted.
    /// </summary>
    /// <param name="timeFormat">Time format</param>
    /// <returns></returns>
    public static string Format(string timeFormat)
    {
        return DateTime.Now.ToString(timeFormat);
    }

    /// <summary>
    /// Gets the current Unix timestamp, since January 1, 1970
    /// </summary>
    /// <returns>Returns the current Unix timestamp</returns>
    public static long GetUnixTimestamp()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
}
