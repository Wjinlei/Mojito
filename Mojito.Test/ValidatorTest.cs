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
    public void TestIsLetter1()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123123", false },
            { "123abc", false },
            { "abc123", false },
            { "!@#$%^&*=", false },
            { "abc123!@#", false },
            { "!@#abc123", false },
            { "123!@#abc", false },
            { "abcabc", true },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsLetter(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsLetter2()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123123551", false },
            { "123abc123", false },
            { "abc123abc", false },
            { "!@#$%^&*=", false },
            { "abc123!@#", false },
            { "!@#abc123", false },
            { "123!@#abc", false },
            { "abcabcabc", true },
            { "abcabcabcabc", false },
            { "abc", false },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsLetter(str.Key, 8, 10);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsDigit1()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123abc", false },
            { "abc123", false },
            { "abcabc", false },
            { "!@#$%^&*=", false },
            { "abc123!@#", false },
            { "!@#abc123", false },
            { "123!@#abc", false },
            { "123123", true },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsDigit(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsDigit2()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123abc123", false },
            { "abc123abc", false },
            { "abcabcabc", false },
            { "!@#$%^&*=", false },
            { "abc123!@#", false },
            { "!@#abc123", false },
            { "123!@#abc", false },
            { "123123551", true },
            { "111223123551", false },
            { "123", false },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsDigit(str.Key, 8, 10);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsAlpha1()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123123", false },
            { "abcabc", false },
            { "abc123!@#", false },
            { "!@#abc123", false },
            { "123!@#abc", false },
            { "123abc", true },
            { "abc123", true },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsAlpha(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsAlpha2()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123123123", false },
            { "abcabcabc", false },
            { "abc123!@#", false },
            { "!@#abc123", false },
            { "123!@#abc", false },
            { "123abc123", true },
            { "abc123abc", true },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsAlpha(str.Key, 8, 10);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsComplex1()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "123123123", false },
            { "abcabcabc", false },
            { "abc123abc", false },
            { "123abc123", false },
            { "!@#$%^&*:", false },
            { "abc123@#!", true },
            { "123abc@#!", true },
            { "@#!abc123", true },
            { "@#!123abc", true }
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsComplex(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsComplex2()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "abcabcabc", false },
            { "123123123", false },
            { "abc123abc", false },
            { "123abc123", false },
            { "!@#$%^&*:", false },
            { "abc123@#!", true },
            { "123abc@#!", true },
            { "@#!abc123", true },
            { "abc123@#!()", false },
            { "a13@", false },
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsComplex(str.Key, 8, 10);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
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
