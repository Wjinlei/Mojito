namespace Mojito.Test.Crypto;

public class Md5Test
{
    [Test]
    public void TestSum()
    {
        var str = "Hello 中国!";
        var bytes = System.Text.Encoding.UTF8.GetBytes(str);

        var result1 = Mojito.Crypto.Md5.Sum(str);
        Assert.That(result1, Is.EqualTo("dd17cdf3b174ce79dc3f722f1bf1543a"));

        var result2 = Mojito.Crypto.Md5.Sum(bytes);
        Assert.That(result2, Is.EqualTo("dd17cdf3b174ce79dc3f722f1bf1543a"));
    }

    [Test]
    public void TestFileSum()
    {
        var result = Mojito.Crypto.Md5.FileSum("test_file.txt");
        Assert.That(result, Is.EqualTo("5f879271784946b093d424b637b3a6f9"));
    }

    [TearDown]
    public void Clear()
    {
        File.Delete("test_file.txt");
    }
}
