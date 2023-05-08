namespace Mojito.Test.Convert;

public class UriTest
{
    [Test]
    public void TestToHost()
    {
        var uri = "https://www.example.com/admin/login.php?username=admin&password=admin123";
        var result = Mojito.Convert.Uri.ToHost(uri);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo("www.example.com"));
        });
    }
}
