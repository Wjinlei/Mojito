using System.Text;

namespace Mojito;

public static class Convert
{
    private static readonly Encoding GBKEncoding;

    static Convert()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        GBKEncoding = Encoding.GetEncoding("GBK");
    }


    /// <summary>
    /// Convert byte array to UTF8 string
    /// </summary>
    /// <param name="bytes">byte array</param>
    /// <returns></returns>
    public static string UTF8(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// Decode strings into byte arrays using UTF8 encoding
    /// </summary>
    /// <param name="bytes">byte array</param>
    /// <returns></returns>
    public static byte[] UTF8Bytes(string text)
    {
        return Encoding.UTF8.GetBytes(text);
    }

    /// <summary>
    /// Convert byte array to GBK string
    /// </summary>
    /// <param name="bytes">byte array</param>
    /// <returns></returns>
    public static string GBK(byte[] bytes)
    {
        return GBKEncoding.GetString(bytes);
    }

    /// <summary>
    /// Decode strings into byte arrays using GBK encoding
    /// </summary>
    /// <param name="bytes">byte array</param>
    /// <returns></returns>
    public static byte[] GBKBytes(string text)
    {
        return GBKEncoding.GetBytes(text);
    }

    /// <summary>
    /// UTF8 character string to GBK character string
    /// </summary>
    /// <param name="text">The string to be converted</param>
    /// <returns></returns>
    public static Result<string> UTF8ToGBK(string text)
    {
        try
        {
            var result = UTF8ToGBK(UTF8Bytes(text));
            if (!result.Success)
                return result.GetError();

            return GBK(result.GetOk());
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex);
        }
    }

    /// <summary>
    /// UTF8 byte array to GBK byte array
    /// </summary>
    /// <param name="utf8Bytes">The array of bytes to be converted</param>
    /// <returns></returns>
    public static Result<byte[]> UTF8ToGBK(byte[] utf8Bytes)
    {
        try
        {
            return Encoding.Convert(Encoding.UTF8, GBKEncoding, utf8Bytes);
        }
        catch (Exception ex)
        {
            return Result<byte[]>.Error(ex);
        }
    }

    /// <summary>
    /// GBK character string to UTF8 character string
    /// </summary>
    /// <param name="text">The string to be converted</param>
    /// <returns></returns>
    public static Result<string> GBKToUTF8(string text)
    {
        try
        {
            var result = GBKToUTF8(GBKBytes(text));
            if (!result.Success)
                return result.GetError();

            return UTF8(result.GetOk());
        }
        catch (Exception ex)
        {
            return Result <string>.Error(ex);
        }
    }

    /// <summary>
    /// GBK byte array to UTF8 byte array
    /// </summary>
    /// <param name="gbkBytes">The array of bytes to be converted</param>
    /// <returns></returns>
    public static Result<byte[]> GBKToUTF8(byte[] gbkBytes)
    {
        try
        {
            return Encoding.Convert(GBKEncoding, Encoding.UTF8, gbkBytes);
        }
        catch (Exception ex)
        {
            return Result < byte[]>.Error(ex);
        }
    }

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
