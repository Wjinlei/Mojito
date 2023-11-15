using System.Security.Cryptography;

namespace Mojito.Crypto;

public static class Md5
{
    /// <summary>
    /// Calculates the md5 value of the file
    /// </summary>
    /// <param name="filepath">File path</param>
    /// <returns></returns>
    public static string FileSum(string filepath)
    {
        return Sum(File.ReadAllBytes(filepath));
    }

    /// <summary>
    /// Calculates the MD5 value for the string
    /// </summary>
    /// <param name="text">Text string</param>
    /// <returns></returns>
    public static string Sum(string text)
    {
        return Sum(System.Text.Encoding.UTF8.GetBytes(text));
    }

    /// <summary>
    /// Calculates the md5 value for the byte[] array
    /// </summary>
    /// <param name="byteArray">byte[] array</param>
    /// <returns></returns>
    public static string Sum(byte[] byteArray)
    {
        MD5 md5 = MD5.Create();
        byte[] hashBytes = md5.ComputeHash(byteArray);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}
