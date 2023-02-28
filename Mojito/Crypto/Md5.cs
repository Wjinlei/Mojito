using System.Security.Cryptography;
using System.Text;

namespace Mojito.Crypto;

public static class Md5
{
    /// <summary>
    /// Calculates the md5 value of the file
    /// </summary>
    /// <param name="filepath">File path</param>
    /// <returns></returns>
    public static Result<string> F(string filepath)
    {
        var result = IO.File.ReadAllBytes(filepath);
        if (!result.Success)
            return Result<string>.Error(result.GetError());

        return Sum(result.GetOk());
    }

    /// <summary>
    /// Calculates the MD5 value for the string
    /// </summary>
    /// <param name="text">Text string</param>
    /// <returns></returns>
    public static Result<string> Sum(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        return Sum(bytes);
    }

    /// <summary>
    /// Calculates the md5 value for the byte[] array
    /// </summary>
    /// <param name="byteArray">byte[] array</param>
    /// <returns></returns>
    public static Result<string> Sum(byte[] byteArray)
    {
        try
        {
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(byteArray);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex);
        }
    }
}
