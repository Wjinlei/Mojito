namespace Mojito.Convert;

public static class String
{
    /// <summary>
    /// Convert.ToInt16 or default value
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">If the conversion fails, this default value is returned</param>
    /// <returns></returns>
    public static short ToInt16OrDefault(string value, short defaultValue)
    {
        try
        {
            return System.Convert.ToInt16(value);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// Convert.ToInt32 or default value
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">If the conversion fails, this default value is returned</param>
    /// <returns></returns>
    public static int ToInt32OrDefault(string value, int defaultValue)
    {
        try
        {
            return System.Convert.ToInt32(value);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// Convert.ToInt64 or default value
    /// </summary>
    /// <param name="value">The value to be converted</param>
    /// <param name="defaultValue">If the conversion fails, this default value is returned</param>
    /// <returns></returns>
    public static long ToInt64OrDefault(string value, long defaultValue)
    {
        try
        {
            return System.Convert.ToInt64(value);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}
