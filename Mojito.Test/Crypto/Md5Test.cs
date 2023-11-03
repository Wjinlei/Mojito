namespace Mojito.Test.Crypto;

public class Md5Test
{
    [Test]
    public void TestSum1()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("Hello 中国!");
        var result = Mojito.Crypto.Md5.Sum(bytes);
        Assert.That(result, Is.EqualTo("dd17cdf3b174ce79dc3f722f1bf1543a"));
    }

    [Test]
    public void TestSum2()
    {
        var result = Mojito.Crypto.Md5.Sum("Hello 中国!");
        Assert.That(result, Is.EqualTo("dd17cdf3b174ce79dc3f722f1bf1543a"));
    }

    [Test]
    public void TestFileSum()
    {
        Mojito.IO.File.WriteAllText("test_file.txt", "Hello World!");
        var result = Mojito.Crypto.Md5.FileSum("test_file.txt");
        Assert.That(result, Is.EqualTo("28c637ace8581c8c27e1aa62def3602d"));
    }

    [TearDown]
    public void Clear()
    {
        Mojito.IO.File.Delete("test_file.txt");
    }
}
