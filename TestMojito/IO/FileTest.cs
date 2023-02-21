namespace TestMojito.IO;

public class FileTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCreate1()
    {
        var result = Mojito.IO.File.Create("test_file.txt");
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestCreate2()
    {
        var result = Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        Assert.That(result.Success, Is.True);
    }
}