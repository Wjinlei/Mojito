namespace Mojito.Test.IO;

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
        Mojito.IO.File.Create("test_file.txt").Close();
        // Test Overwrite
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();

        Assert.That(Mojito.IO.File.Exists("test_file.txt"), Is.True);
    }

    [Ignore("[Ignore]: Administrator permissions required")]
    [Test]
    public void TestCreateSymbolicLink()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();
        Mojito.IO.File.CreateSymbolicLink("test_file.txt.lnk", "test_file.txt");

        Assert.That(Mojito.IO.File.Exists("test_file.txt.lnk"), Is.True);
    }

    [Test]
    public void TestDelete()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();
        Mojito.IO.File.Delete("test_file.txt");

        Assert.That(Mojito.IO.File.Exists("test_file.txt"), Is.False);
    }

    [Test]
    public void TestMove()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();
        Mojito.IO.File.Move("test_file.txt", "move_test_file.txt");
        // Test Overwrite
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();
        Mojito.IO.File.Move("test_file.txt", "move_test_file.txt", true);

        Assert.Multiple(() =>
        {
            Assert.That(Mojito.IO.File.Exists("test_file.txt"), Is.False);
            Assert.That(Mojito.IO.File.Exists("move_test_file.txt"), Is.True);
        });
    }

    [Test]
    public void TestCopy()
    {
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();
        Mojito.IO.File.Copy("test_file.txt", "copy_test_file.txt");
        // Test Overwrite
        Mojito.IO.File.Create("test_file.txt", FileMode.Create).Close();
        Mojito.IO.File.Copy("test_file.txt", "copy_test_file.txt", true);

        Assert.Multiple(() =>
        {
            Assert.That(Mojito.IO.File.Exists("test_file.txt"), Is.True);
            Assert.That(Mojito.IO.File.Exists("copy_test_file.txt"), Is.True);
        });
    }

    [Test]
    public void TestWriteAllText()
    {
        Mojito.IO.File.WriteAllText("test_file.txt", "Hello World!");
        Mojito.IO.File.WriteAllText("test_file.txt", "Hello World!", System.Text.Encoding.UTF8);

        var result = Mojito.IO.File.ReadAllText("test_file.txt");
        Assert.That(result, Is.EqualTo("Hello World!"));
    }

    [Test]
    public void TestWriteAllLines()
    {
        var lines = new[] { "Hello C#", "Hello World!" };
        Mojito.IO.File.WriteAllLines("test_file.txt", lines);
        Mojito.IO.File.WriteAllLines("test_file.txt", lines, System.Text.Encoding.UTF8);

        var readLines = Mojito.IO.File.ReadAllLines("test_file.txt");
        Assert.That(readLines, Is.EquivalentTo(lines));
    }

    [Test]
    public void TestWriteAllBytes()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("Hello World!");
        Mojito.IO.File.WriteAllBytes("test_file.txt", bytes);

        var result = Mojito.IO.File.ReadAllBytes("test_file.txt");
        Assert.That(result, Is.EqualTo(bytes));
    }

    [Test]
    public void TestAppendAllText()
    {
        Mojito.IO.File.AppendAllText("test_file.txt", "Hello World!");
        Mojito.IO.File.AppendAllText("test_file.txt", "Hello World!", System.Text.Encoding.UTF8);

        var result = Mojito.IO.File.ReadAllText("test_file.txt");
        Assert.That(result, Is.EqualTo("Hello World!Hello World!"));
    }

    [Test]
    public void TestAppendAllLines()
    {
        var lines1 = new[] { "Hello C#!", "Hello World!" };
        var lines2 = new[] { "Hello CSharp!", "Hello!" };
        Mojito.IO.File.AppendAllLines("test_file.txt", lines1);
        Mojito.IO.File.AppendAllLines("test_file.txt", lines2, System.Text.Encoding.UTF8);

        var result = Mojito.IO.File.ReadAllText("test_file.txt");
        Assert.That(result, Is.EqualTo($"Hello C#!{Environment.NewLine}Hello World!{Environment.NewLine}Hello CSharp!{Environment.NewLine}Hello!{Environment.NewLine}"));
    }

    [Test]
    public void TestReadAllText()
    {
        var lines = new[] { "Hello C#!", "Hello World!" };
        Mojito.IO.File.WriteAllLines("test_file.txt", lines);

        var result1 = Mojito.IO.File.ReadAllText("test_file.txt");
        var result2 = Mojito.IO.File.ReadAllText("test_file.txt", System.Text.Encoding.UTF8);

        Assert.Multiple(() =>
        {
            Assert.That(result1, Is.EqualTo($"Hello C#!{Environment.NewLine}Hello World!{Environment.NewLine}"));
            Assert.That(result2, Is.EqualTo($"Hello C#!{Environment.NewLine}Hello World!{Environment.NewLine}"));
        });
    }

    [Test]
    public void TestReadLines()
    {
        var lines = new[] { "Hello C#!", "Hello World!" };
        Mojito.IO.File.WriteAllLines("test_file.txt", lines);

        var result1 = Mojito.IO.File.ReadLines("test_file.txt");
        var result2 = Mojito.IO.File.ReadLines("test_file.txt", System.Text.Encoding.UTF8);

        Assert.Multiple(() =>
        {
            Assert.That(result1.Count, Is.EqualTo(2));
            Assert.That(result2.Count, Is.EqualTo(2));
        });
    }

    [Test]
    public void TestReadAllLines()
    {
        var lines = new[] { "Hello C#!", "Hello World!" };
        Mojito.IO.File.WriteAllLines("test_file.txt", lines);

        var result1 = Mojito.IO.File.ReadAllLines("test_file.txt");
        var result2 = Mojito.IO.File.ReadAllLines("test_file.txt", System.Text.Encoding.UTF8);

        Assert.Multiple(() =>
        {
            Assert.That(result1, Is.EqualTo(lines));
            Assert.That(result2, Is.EqualTo(lines));
        });
    }

    [Test]
    public void TestReadAllBytes()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("Hello World!");
        Mojito.IO.File.WriteAllBytes("test_file.txt", bytes);

        var result = Mojito.IO.File.ReadAllBytes("test_file.txt");

        Assert.That(result, Is.EqualTo(bytes));
    }
}