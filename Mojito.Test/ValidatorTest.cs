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
    public void TestIsDigit()
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
        var ok1 = Validator.IsAlpha("123");
        var ok2 = Validator.IsAlpha("abc");
        var ok3 = Validator.IsAlpha("abc123");
        var ok4 = Validator.IsAlpha("abc123", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.False);
            Assert.That(ok2, Is.False);
            Assert.That(ok3, Is.True);
            Assert.That(ok4, Is.True);
        });
    }

    [Test]
    public void TestIsComplex()
    {
        var ok1 = Validator.IsComplex("123");
        var ok2 = Validator.IsComplex("abc");
        var ok3 = Validator.IsComplex("abc123");
        var ok4 = Validator.IsComplex("123sdf");
        var ok5 = Validator.IsComplex("123sdf!@#");
        var ok6 = Validator.IsComplex("!@3123sdf");
        var ok7 = Validator.IsComplex("gsd!@3123");
        var ok8 = Validator.IsComplex("321!@31a", 1, 10);
        Assert.Multiple(() =>
        {
            Assert.That(ok1, Is.False);
            Assert.That(ok2, Is.False);
            Assert.That(ok3, Is.False);
            Assert.That(ok4, Is.False);
            Assert.That(ok5, Is.True);
            Assert.That(ok6, Is.True);
            Assert.That(ok7, Is.True);
            Assert.That(ok8, Is.True);
        });
    }

    [Test]
    public void TestIsDomain()
    {
        var domains = new[] {
            "xn--fiqs8s.cn",
            "example.com",
            "qq.com",
            "example.test.cn",
            "6.cn",
            "test.co.net"
        };

        foreach (var domain in domains)
        {
            var ok = Validator.IsDomain(domain);
            Assert.That(ok, Is.True);
        }
    }
}
