using System.Security.Cryptography;

namespace Mojito.Test.Crypto;

public class AESTest
{
    [Test]
    public void TestGbkAesEncryptToHex()
    {
        string original = "Hello 中国!";
        var result = Mojito.Crypto.AES.GbkAesEncryptToHex(original, "123", CipherMode.ECB, PaddingMode.Zeros);
        Assert.That(result, Is.EqualTo("25EB8D9F60D78F95486D103234AEBF09"));
    }

    [Test]
    public void TestUtf8AesEncryptToHex()
    {
        string original = "Hello 中国!";
        var result = Mojito.Crypto.AES.Utf8AesEncryptToHex(original, "123", CipherMode.ECB, PaddingMode.Zeros);
        Assert.That(result, Is.EqualTo("D6A86C84E12411F5C9326ECB31A50359"));
    }

    [Test]
    public void TestGbkAesDecryptFromHex()
    {
        var cipherText = "25EB8D9F60D78F95486D103234AEBF09";
        var result = Mojito.Crypto.AES.GbkAesDecryptFromHex(cipherText, "123", CipherMode.ECB, PaddingMode.Zeros);
        Assert.That(result, Is.EqualTo("Hello 中国!"));
    }

    [Test]
    public void TestUtf8AesDecryptFromHex()
    {
        var cipherText = "D6A86C84E12411F5C9326ECB31A50359";
        var result = Mojito.Crypto.AES.Utf8AesDecryptFromHex(cipherText, "123", CipherMode.ECB, PaddingMode.Zeros);
        Assert.That(result, Is.EqualTo("Hello 中国!"));
    }
}
