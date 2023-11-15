namespace Mojito.Test.IOUtil;

public class DirectoryTest
{

    [TearDown]
    public void Clear()
    {
        try
        {
            Directory.Delete("test_dir1", true);
            Directory.Delete("test_dir2", true);
        }
        catch (DirectoryNotFoundException)
        {
            // 如果要删除的目录不存在，就吞掉这个异常，无所谓，不需要报错
        }
    }
    [Test]
    public void TsetCopy()
    {
        Directory.CreateDirectory("test_dir1/test_dir2");
        File.WriteAllText("test_dir1/test_file.txt", "Hello World!");
        File.WriteAllText("test_dir1/test_dir2/test_file.txt", "Hello World!");
        Mojito.IOUtil.Directory.Copy("test_dir1", "test_dir2");
        Assert.Multiple(() =>
        {
            Assert.That(File.Exists("test_dir2/test_file.txt"), Is.True);
            Assert.That(File.Exists("test_dir2/test_dir2/test_file.txt"), Is.True);
        });
    }
}
