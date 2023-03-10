namespace TestMojito;

public class UriTest
{
    [Test]
    public void TestUri()
    {
        // Support format:

        // 8080
        // :8080
        // :8080:
        // www.test.com
        // www.test.com:8080
        // www.test.com:8080:
        // www.test.com:8080:adfs
        // www.test.com:8080/logout.php?clear=true
        // http://www.test.com
        // http://www.test.com:8080
        // http://www.test.com:8080:
        // http://www.test.com:8080:afsadf
        // http://www.test.com:8080/logout.php?clear=true

        var uri = new Mojito.Uri("www.test.com:8080");
        Assert.Multiple(() =>
        {
            Assert.That(uri.Host, Is.EqualTo("www.test.com"));
            Assert.That(uri.Port, Is.EqualTo(8080));
        });
    }
}
