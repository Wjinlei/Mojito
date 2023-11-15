namespace Mojito.Convert;

public static class GBK
{
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
