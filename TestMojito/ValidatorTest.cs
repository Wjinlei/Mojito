namespace TestMojito;

public class ValidatorTest
{
    [Test]
    public void TestIsEmail()
    {
        var ok = Mojito.Validator.IsEmail("service@adm.net");
        Assert.That(ok, Is.True);
    }

    [Test]
    public void TestIsLetter()
    {
        var ok1 = Mojito.Validator.IsLetter("example");
        var ok2 = Mojito.Validator.IsLetter("example", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }

    [Test]
    public void TestIsDight()
    {
        var ok1 = Mojito.Validator.IsDigit("123");
        var ok2 = Mojito.Validator.IsDigit("123", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }

    [Test]
    public void TestIsAlpha()
    {
        var ok1 = Mojito.Validator.IsAlpha("abc123");
        var ok2 = Mojito.Validator.IsAlpha("abc123", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }
}
