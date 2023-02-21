namespace TestMojito.IO;

public class FileTest
{
    [SetUp]
    public void Setup()
    {
        Mojito.IO.File.Delete("test_file.txt");
        Mojito.IO.File.Delete("move_test_file.txt");
        Mojito.IO.File.Delete("copy_test_file.txt");
    }

    [Test]
    public void TestCreate()
    {
        var result1 = Mojito.IO.File.Create("test_file.txt");
        var result2 = Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
        });
    }

    [Ignore("[Ignore]: Administrator permissions required")]
    [Test]
    public void TestCreateSymbolicLink()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        var result = Mojito.IO.File.CreateSymbolicLink("test_file.txt.lnk", "test_file.txt");
        Assert.That(result.Success, Is.True);

    }

    [Test]
    public void TestDelete()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        var result = Mojito.IO.File.Delete("test_file.txt");
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestMove()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        var result1 = Mojito.IO.File.Move("test_file.txt", "move_test_file.txt");

        Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        var result2 = Mojito.IO.File.Move("test_file.txt", "move_test_file.txt", true);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
        });
    }

    [Test]
    public void TestCopy()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        var result1 = Mojito.IO.File.Copy("test_file.txt", "copy_test_file.txt");

        Mojito.IO.File.Create("test_file.txt", FileMode.Create);
        var result2 = Mojito.IO.File.Copy("test_file.txt", "copy_test_file.txt", true);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
        });
    }

    [Test]
    public void TestWriteAllText()
    {
        var result1 = Mojito.IO.File.WriteAllText("test_file.txt", "Hello World!");
        var result2 = Mojito.IO.File.WriteAllText("test_file.txt", "Hello World!", System.Text.Encoding.UTF8);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
        });
    }

    [Test]
    public void TestWriteAllLines()
    {
        var lines = new[] { "Hello C#", "Hello World!" };
        var result1 = Mojito.IO.File.WriteAllLines("test_file.txt", lines);
        var result2 = Mojito.IO.File.WriteAllLines("test_file.txt", lines, System.Text.Encoding.UTF8);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
        });
    }

    [Test]
    public void TestWriteAllBytes()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("Hello World!");
        var result = Mojito.IO.File.WriteAllBytes("test_file.txt", bytes);
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestAppendAllText()
    {
        var result1 = Mojito.IO.File.AppendAllText("test_file.txt", "Hello World!");
        var result2 = Mojito.IO.File.AppendAllText("test_file.txt", "Hello World!", System.Text.Encoding.UTF8);
        var result3 = Mojito.IO.File.ReadAllText("test_file.txt");
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
            Assert.That(result3.Success, Is.True);
            Assert.That(result3.GetOk(), Is.EqualTo("Hello World!Hello World!"));
        });
    }

    [Test]
    public void TestAppendAllLines()
    {
        var lines1 = new[] { "Hello C#!", "Hello World!" };
        var lines2 = new[] { "Hello CSharp!", "Hello!" };
        var result1 = Mojito.IO.File.AppendAllLines("test_file.txt", lines1);
        var result2 = Mojito.IO.File.AppendAllLines("test_file.txt", lines2, System.Text.Encoding.UTF8);
        var result3 = Mojito.IO.File.ReadAllText("test_file.txt");
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(result2.Success, Is.True);
            Assert.That(result3.Success, Is.True);
            Assert.That(result3.GetOk(), Is.EqualTo($"Hello C#!{Environment.NewLine}Hello World!{Environment.NewLine}Hello CSharp!{Environment.NewLine}Hello!{Environment.NewLine}"));
        });
    }
}