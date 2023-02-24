using System.Text;

namespace Mojito;

public static class Convert
{
    /// <summary>
    /// UTF8 character string to GBK character string
    /// </summary>
    /// <param name="text">The string to be converted</param>
    /// <returns></returns>
    public static Result<string> UTF8ToGBK(string text)
    {
        try
        {
            var utf8Bytes = Encoding.UTF8.GetBytes(text);
            var result = UTF8ToGBK(utf8Bytes);
            if (!result.Success)
                return Result<string>.Error(result.GetError());

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var gbk = Encoding.GetEncoding("GBK");
            var gbkText = gbk.GetString(utf8Bytes);
            return Result<string>.Ok(gbkText);
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var gbk = Encoding.GetEncoding("GBK");
            var gbkBytes = Encoding.Convert(Encoding.UTF8, gbk, utf8Bytes);
            return Result<byte[]>.Ok(gbkBytes);
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var gbk = Encoding.GetEncoding("GBK");
            var gbkBytes = gbk.GetBytes(text);
            var result = GBKToUTF8(gbkBytes);
            if (!result.Success)
                return Result<string>.Error(result.GetError());
            var utf8Text = Encoding.UTF8.GetString(result.GetOk());
            return Result<string>.Ok(utf8Text);
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex);
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var gbk = Encoding.GetEncoding("GBK");
            var utf8Bytes = Encoding.Convert(gbk, Encoding.UTF8, gbkBytes);
            return Result<byte[]>.Ok(utf8Bytes);
        }
        catch (Exception ex)
        {
            return Result<byte[]>.Error(ex);
        }
    }

    /// <summary>
    /// Hexadecimal string to byte[] array<br/>
    /// https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/types/how-to-convert-between-hexadecimal-strings-and-numeric-types
    /// </summary>
    /// <param name="hexString">Hexadecimal character</param>
    /// <returns></returns>
    public static byte[] HexToBytes(string hexString)
    {
        byte[] byteArray = new byte[hexString.Length / 2];
        for (var i = 0; i < byteArray.Length; i++)
        {
            var hexChar = hexString.Substring(i * 2, 2);
            byteArray[i] = (byte)System.Convert.ToInt32(hexChar, 16);
        }
        return byteArray;
    }
}
