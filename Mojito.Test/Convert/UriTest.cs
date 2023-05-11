namespace Mojito.Test.Convert;

public class UriTest
{
    [Test]
    public void TestToHost()
    {
        var uri = "https://www.example.com/admin/login.php?username=admin&password=admin123";
        var host = Mojito.Convert.Uri.ToHost(uri);
        Assert.That(host, Is.EqualTo("www.example.com"));
    }

    [Test]
    public void TestToPort()
    {
        var uri = "https://www.example.com/admin/login.php?username=admin&password=admin123";
        var port = Mojito.Convert.Uri.ToPort(uri);
        Assert.That(port, Is.EqualTo(443));
    }
}
