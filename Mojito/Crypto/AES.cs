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
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static byte[] AesEncrypt(string plainText, string key, /*int keyLength,*/ CipherMode cipherMode, PaddingMode paddingMode, System.Text.Encoding encoding)
    {
        if (plainText == null || plainText.Length <= 0)
            throw new InvalidOperationException("plainText cannot be empty");

        //if (keyLength != 16 && keyLength != 24 && keyLength != 32)
        //    throw new ArgumentOutOfRangeException("The key length must be one of 16/24/32"));

        var keyLength = 16; // 固定使用16位的key

        byte[] oldKey;
        byte[] newKey = new byte[keyLength];
        oldKey = encoding.GetBytes(key);
        Buffer.BlockCopy(oldKey, 0, newKey, 0, oldKey.Length);

        using var aes = Aes.Create();
        aes.Key = newKey;
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using MemoryStream msEncrypt = new();

        {
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt, encoding);
            swEncrypt.Write(plainText);
        }


        byte[] encrypted;
        encrypted = msEncrypt.ToArray();

        return encrypted;
    }

    public static string GbkAesEncryptToHex(string plainText, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        return Convert.ToHexString(AesEncrypt(plainText, key, cipherMode, paddingMode, System.Text.Encoding.GetEncoding("GBK")));
    }

    public static string Utf8AesEncryptToHex(string plainText, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        return Convert.ToHexString(AesEncrypt(plainText, key, cipherMode, paddingMode, System.Text.Encoding.UTF8));
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
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string AesDecrypt(byte[] encrypted, string key, /*int keyLength,*/ CipherMode cipherMode, PaddingMode paddingMode, System.Text.Encoding encoding)
    {
        if (encrypted == null || encrypted.Length <= 0)
            throw new InvalidOperationException("encrypted cannot be empty");

        //if (keyLength != 16 && keyLength != 24 && keyLength != 32)
        //    throw new ArgumentOutOfRangeException("The key length must be one of 16/24/32"));

        var keyLength = 16; // 固定使用16位key

        byte[] oldKey;
        byte[] newKey = new byte[keyLength];

        oldKey = encoding.GetBytes(key);
        Buffer.BlockCopy(oldKey, 0, newKey, 0, oldKey.Length);

        using var aes = Aes.Create();
        aes.Key = newKey;
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream msDecrypt = new(encrypted);
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt, encoding);

        var plainText = srDecrypt.ReadToEnd().TrimEnd('\0');
        return plainText;
    }

    public static string GbkAesDecryptFromHex(string hex, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encrypted = Convert.FromHexString(hex);
        System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        return AesDecrypt(encrypted, key, cipherMode, paddingMode, System.Text.Encoding.GetEncoding("GBK"));
    }

    public static string Utf8AesDecryptFromHex(string hex, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encrypted = Convert.FromHexString(hex);
        return AesDecrypt(encrypted, key, cipherMode, paddingMode, System.Text.Encoding.UTF8);
    }
}
