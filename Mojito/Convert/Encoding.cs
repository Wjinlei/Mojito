namespace Mojito.Convert;

public static class Encoding
{
    private static readonly System.Text.Encoding GBK;

    static Encoding()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        GBK = System.Text.Encoding.GetEncoding("GBK");
    }


    /// <summary>
    /// Convert byte array to UTF8 string
    /// </summary>
    /// <param name="bytes">byte array</param>
    /// <returns></returns>
    public static string Utf8(byte[] bytes)
    {
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// Decode strings into byte arrays using UTF8 encoding
    /// </summary>
    /// <param name="text">utf8 string</param>
    /// <returns></returns>
    public static byte[] Utf8GetBytes(string text)
    {
        return System.Text.Encoding.UTF8.GetBytes(text);
    }

    /// <summary>
    /// Convert byte array to GBK string
    /// </summary>
    /// <param name="bytes">byte array</param>
    /// <returns></returns>
    public static string Gbk(byte[] bytes)
    {
        return GBK.GetString(bytes);
    }

    /// <summary>
    /// Decode strings into byte arrays using GBK encoding
    /// </summary>
    /// <param name="text">gbk string</param>
    /// <returns></returns>
    public static byte[] GbkGetBytes(string text)
    {
        return GBK.GetBytes(text);
    }

    /// <summary>
    /// UTF8 character string to GBK character string
    /// </summary>
    /// <param name="text">utf8 string</param>
    /// <returns></returns>
    public static Result<string> Utf8ToGbk(string text)
    {
        try
        {
            var result = Utf8ToGbk(Utf8GetBytes(text));
            if (!result.Success)
                return result.GetError();

            return Gbk(result.GetOk());
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// UTF8 byte array to GBK byte array
    /// </summary>
    /// <param name="utf8Bytes">byte array</param>
    /// <returns></returns>
    public static Result<byte[]> Utf8ToGbk(byte[] utf8Bytes)
    {
        try
        {
            return System.Text.Encoding.Convert(System.Text.Encoding.UTF8, GBK, utf8Bytes);
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// GBK character string to UTF8 character string
    /// </summary>
    /// <param name="text">gbk string</param>
    /// <returns></returns>
    public static Result<string> GbkToUtf8(string text)
    {
        try
        {
            var result = GbkToUtf8(GbkGetBytes(text));
            if (!result.Success)
                return result.GetError();

            return Utf8(result.GetOk());
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// GBK byte array to UTF8 byte array
    /// </summary>
    /// <param name="gbkBytes">byte array</param>
    /// <returns></returns>
    public static Result<byte[]> GbkToUtf8(byte[] gbkBytes)
    {
        try
        {
            return System.Text.Encoding.Convert(GBK, System.Text.Encoding.UTF8, gbkBytes);
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
