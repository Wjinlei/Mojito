namespace Mojito.Convert;

public static class Encoding
{
    /// <summary>
    /// UTF8 character string to GBK character string
    /// </summary>
    /// <param name="text">utf8 string</param>
    /// <returns></returns>
    public static string Utf8ToGbk(string text)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        var gbk = System.Text.Encoding.GetEncoding("GBK");
        return gbk.GetString(Utf8ToGbk(System.Text.Encoding.UTF8.GetBytes(text)));
    }

    /// <summary>
    /// UTF8 byte array to GBK byte array
    /// </summary>
    /// <param name="utf8Bytes">byte array</param>
    /// <returns></returns>
    public static byte[] Utf8ToGbk(byte[] utf8Bytes)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        var gbk = System.Text.Encoding.GetEncoding("GBK");
        return System.Text.Encoding.Convert(System.Text.Encoding.UTF8, gbk, utf8Bytes);
    }

    /// <summary>
    /// GBK character string to UTF8 character string
    /// </summary>
    /// <param name="text">gbk string</param>
    /// <returns></returns>
    public static string GbkToUtf8(string text)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        var gbk = System.Text.Encoding.GetEncoding("GBK");
        return System.Text.Encoding.UTF8.GetString(GbkToUtf8(gbk.GetBytes(text)));
    }

    /// <summary>
    /// GBK byte array to UTF8 byte array
    /// </summary>
    /// <param name="gbkBytes">byte array</param>
    /// <returns></returns>
    public static byte[] GbkToUtf8(byte[] gbkBytes)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        var gbk = System.Text.Encoding.GetEncoding("GBK");
        return System.Text.Encoding.Convert(gbk, System.Text.Encoding.UTF8, gbkBytes);
    }
}
