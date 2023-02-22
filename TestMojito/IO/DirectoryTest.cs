namespace TestMojito.IO;

public class DirectoryTest
{

    [TearDown]
    public void Clear()
    {
        Mojito.IO.Directory.Delete("test_dir1/test_dir2/test_dir3", true);
        Mojito.IO.Directory.Delete("test_dir1/test_dir2", true);
        Mojito.IO.Directory.Delete("test_dir1", true);
        Mojito.IO.Directory.Delete("test_dir2", true);
        Mojito.IO.Directory.Delete("test_dir3", true);
        Mojito.IO.File.Delete("test_dir3.lnk");
    }

    [Test]
    public void TestCreate()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        var result = Mojito.IO.Directory.Create(dir);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(Mojito.IO.Directory.Exists(dir), Is.True);
        });
    }

    [Test]
    public void TestCreateParent()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        var result = Mojito.IO.Directory.CreateParent(dir);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(Mojito.IO.Directory.Exists(dir), Is.False);
            Assert.That(Mojito.IO.Directory.Exists("test_dir1/test_dir2"), Is.True);
        });
    }

    [Ignore("[Ignore]: Administrator permissions required")]
    [Test]
    public void TestCreateSymbolicLink()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        Mojito.IO.Directory.Create(dir);
        var result = Mojito.IO.Directory.CreateSymbolicLink(dir, "test_dir3.lnk");
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestDelete()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        Mojito.IO.Directory.Create(dir);
        var result1 = Mojito.IO.Directory.Delete(dir);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(Mojito.IO.Directory.Exists(dir), Is.False);
        });

        Mojito.IO.Directory.Create(dir);
        Mojito.IO.File.WriteAllText(Path.Combine(dir, "test_file.txt"), "Hello World!");
        var result2 = Mojito.IO.Directory.Delete(dir, true);
        Assert.Multiple(() =>
        {
            Assert.That(result2.Success, Is.True);
            Assert.That(Mojito.IO.Directory.Exists(dir), Is.False);
        });
    }

    [Test]
    public void TestMove()
    {
        Mojito.IO.Directory.Create("test_dir1");
        Mojito.IO.File.WriteAllText("test_dir1/test_file.txt", "Hello World!");
        var result = Mojito.IO.Directory.Move("test_dir1", "test_dir2");
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(Mojito.IO.Directory.Exists("test_dir1"), Is.False);
            Assert.That(Mojito.IO.File.Exists("test_dir2/test_file.txt"), Is.True);
        });
    }

    [Test]
    public void TsetCopy()
    {
        Mojito.IO.Directory.Create("test_dir1/test_dir2");
        Mojito.IO.File.WriteAllText("test_dir1/test_file.txt", "Hello World!");
        Mojito.IO.File.WriteAllText("test_dir1/test_dir2/test_file.txt", "Hello World!");

        var result1 = Mojito.IO.Directory.Copy("test_dir1", "test_dir2");
        var result2 = Mojito.IO.Directory.Copy("test_dir1", "test_dir3", true);
        Assert.Multiple(() =>
        {
            Assert.That(result1.Success, Is.True);
            Assert.That(Mojito.IO.File.Exists("test_dir2/test_file.txt"), Is.True);
            Assert.That(Mojito.IO.File.Exists("test_dir2/test_dir2/test_file.txt"), Is.False);
            Assert.That(result2.Success, Is.True);
            Assert.That(Mojito.IO.File.Exists("test_dir3/test_file.txt"), Is.True);
            Assert.That(Mojito.IO.File.Exists("test_dir3/test_dir2/test_file.txt"), Is.True);
        });
    }
}
