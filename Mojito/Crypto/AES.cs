using System.Security.Cryptography;
using System.Text;

namespace Mojito.Crypto;

public static class AES
{
    /// <summary>
    /// Reference document：https://learn.microsoft.com/zh-cn/dotnet/api/system.security.cryptography.aes
    /// </summary>
    /// <param name="plainText">The plaintext string to be encrypted</param>
    /// <param name="key">Represents the secret key for the symmetric algorithm.</param>
    // <param name="keyLength">The key length must be one of 16/24/32</param>
    /// <param name="cipherMode">Represents the cipher mode used in the symmetric algorithm.</param>
    /// <param name="paddingMode">Represents the padding mode used in the symmetric algorithm.</param>
    /// <param name="encoding">What code is used to encrypt the data.</param>
    /// <returns>Returns an encrypted hexadecimal string</returns>
    public static Result<byte[]> AesEncrypt(string plainText, string key, /*int keyLength,*/ CipherMode cipherMode, PaddingMode paddingMode, Encoding encoding)
    {
        if (plainText == null || plainText.Length <= 0)
            return Result<byte[]>.Error(new InvalidOperationException("plainText cannot be empty"));

        //if (keyLength != 16 && keyLength != 24 && keyLength != 32)
        //    return Result<byte[]>.Error(new ArgumentOutOfRangeException("The key length must be one of 16/24/32"));

        var keyLength = 16; // 固定使用16位的key

        byte[] oldKey;
        byte[] newKey = new byte[keyLength];
        try
        {
            oldKey = encoding.GetBytes(key);
            Buffer.BlockCopy(oldKey, 0, newKey, 0, oldKey.Length);
        }
        catch (Exception ex)
        {
            return Result<byte[]>.Error(new Exception("Build key exception: " + ex.Message));
        }

        using var aes = Aes.Create();
        aes.Key = newKey;
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using MemoryStream msEncrypt = new();
        try
        {
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt, encoding);
            swEncrypt.Write(plainText);
        }
        catch (Exception ex)
        {
            return Result<byte[]>.Error(new Exception("Failed to get encrypted data from the stream: " + ex.Message));
        }

        byte[] encrypted;
        encrypted = msEncrypt.ToArray();

        return encrypted;
    }

    public static Result<string> GbkAesEncryptToHex(string plainText, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var result = AesEncrypt(plainText, key, cipherMode, paddingMode, Encoding.GetEncoding("GBK"));
        if (!result.Success)
            return Result<string>.Error(result.GetError());
        return System.Convert.ToHexString(result.GetOk());
    }

    public static Result<string> Utf8AesEncryptToHex(string plainText, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var result = AesEncrypt(plainText, key, cipherMode, paddingMode, Encoding.UTF8);
        if (!result.Success)
            return Result<string>.Error(result.GetError());
        return System.Convert.ToHexString(result.GetOk());
    }


    /// <summary>
    /// Reference document: https://learn.microsoft.com/zh-cn/dotnet/api/system.security.cryptography.aes
    /// </summary>
    /// <param name="encrypted">byte[] array to be decrypted.</param>
    /// <param name="key">Represents the secret key for the symmetric algorithm.</param>
    // <param name="keyLength">The key length must be one of 16/24/32</param>
    /// <param name="cipherMode">Represents the cipher mode used in the symmetric algorithm.</param>
    /// <param name="paddingMode">Represents the padding mode used in the symmetric algorithm.</param>
    /// <param name="encoding">What code is used to decrypt the data.</param>
    /// <returns>Returns the decrypted content.</returns>
    public static Result<string> AesDecrypt(byte[] encrypted, string key, /*int keyLength,*/ CipherMode cipherMode, PaddingMode paddingMode, Encoding encoding)
    {
        if (encrypted == null || encrypted.Length <= 0)
            return Result<string>.Error(new InvalidOperationException("encrypted cannot be empty"));

        //if (keyLength != 16 && keyLength != 24 && keyLength != 32)
        //    return Result<string>.Error(new ArgumentOutOfRangeException("The key length must be one of 16/24/32"));

        var keyLength = 16; // 固定使用16位key

        byte[] oldKey;
        byte[] newKey = new byte[keyLength];
        try
        {
            oldKey = encoding.GetBytes(key);
            Buffer.BlockCopy(oldKey, 0, newKey, 0, oldKey.Length);
        }
        catch (Exception ex)
        {
            return Result<string>.Error(new Exception("Build key exception: " + ex.Message));
        }

        string? plainText = null;

        using var aes = Aes.Create();
        aes.Key = newKey;
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        try
        {
            using MemoryStream msDecrypt = new(encrypted);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt, encoding);
            plainText = srDecrypt.ReadToEnd().TrimEnd('\0');
        }
        catch (Exception ex)
        {
            return Result<string>.Error(new Exception("Failed to decrypt data from the stream: " + ex.Message));
        }

        return plainText;
    }

    public static Result<string> GbkAesDecryptFromHex(string hex, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encrypted = Convert.HexToBytes(hex);
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        return AesDecrypt(encrypted, key, cipherMode, paddingMode, Encoding.GetEncoding("GBK"));
    }

    public static Result<string> Utf8AesDecryptFromHex(string hex, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encrypted = Convert.HexToBytes(hex);
        return AesDecrypt(encrypted, key, cipherMode, paddingMode, Encoding.UTF8);
    }
}
