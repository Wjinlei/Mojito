namespace Mojito.Test;

public class ValidatorTest
{
    [Test]
    public void TestIsEmail()
    {
        var ok = Validator.IsEmail("service@adm.net");
        Assert.That(ok, Is.True);
    }

    [Test]
    public void TestIsLetter()
    {
        var ok1 = Validator.IsLetter("example");
        var ok2 = Validator.IsLetter("example", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }

    [Test]
    public void TestIsDight()
    {
        var ok1 = Validator.IsDigit("123");
        var ok2 = Validator.IsDigit("123", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }

    [Test]
    public void TestIsAlpha()
    {
        var ok1 = Validator.IsAlpha("abc123");
        var ok2 = Validator.IsAlpha("abc123", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }

    [Test]
    public void TestIsComplex()
    {
        var ok1 = Validator.IsComplex("c#123\\");
        var ok2 = Validator.IsComplex("c#123\\", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.True);
            Assert.That(ok2, Is.True);
        });
    }
}
