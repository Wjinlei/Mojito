namespace Mojito.Convert;

public static class UTF8
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
}
