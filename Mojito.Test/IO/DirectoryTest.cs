namespace Mojito.Test.IO;

public class DirectoryTest
{

    [TearDown]
    public void Clear()
    {
        try
        {
            Mojito.IO.Directory.Delete("test_dir1");
            Mojito.IO.Directory.Delete("test_dir2");
            Mojito.IO.Directory.Delete("test_dir3");
        }
        catch (DirectoryNotFoundException)
        {
            // 如果要删除的目录不存在，就吞掉这个异常，无所谓，不需要报错
        }

        Mojito.IO.File.Delete("test_dir3.lnk");
    }

    [Test]
    public void TestCreate()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        Mojito.IO.Directory.Create(dir);
        Assert.That(Mojito.IO.Directory.Exists(dir), Is.True);

    }

    [Test]
    public void TestCreateParent()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        Mojito.IO.Directory.CreateParent(dir);
        Assert.Multiple(() =>
        {
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

        Mojito.IO.Directory.CreateSymbolicLink(dir, "test_dir3.lnk");
        Assert.That(Mojito.IO.File.Exists("test_dir3.lnk"), Is.True);
    }

    [Test]
    public void TestDelete()
    {
        var dir = "test_dir1/test_dir2/test_dir3";
        Mojito.IO.Directory.Create(dir);
        Mojito.IO.File.WriteAllText(Path.Combine(dir, "test_file.txt"), "Hello World!");

        Mojito.IO.Directory.Delete(dir);
        Assert.Multiple(() =>
        {
            Assert.That(Mojito.IO.Directory.Exists(dir), Is.False);
            Assert.That(Mojito.IO.Directory.Exists("test_dir1/test_dir2"), Is.True);
        });
    }

    [Test]
    public void TestMove()
    {
        Mojito.IO.Directory.Create("test_dir1");
        Mojito.IO.File.WriteAllText("test_dir1/test_file.txt", "Hello World!");

        Mojito.IO.Directory.Move("test_dir1", "test_dir2");
        Assert.Multiple(() =>
        {
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

        Mojito.IO.Directory.Copy("test_dir1", "test_dir3");
        Assert.Multiple(() =>
        {
            Assert.That(Mojito.IO.File.Exists("test_dir3/test_file.txt"), Is.True);
            Assert.That(Mojito.IO.File.Exists("test_dir3/test_dir2/test_file.txt"), Is.True);
        });
    }
}
