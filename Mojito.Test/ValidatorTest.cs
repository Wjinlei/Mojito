namespace Mojito.Test;

public class ValidatorTest
{
    [Test]
    public void TestIsLetter()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "!@^&*=", false }, // Special character
            { "a23!@#", false }, // Special character + number + letter
            { "123123", false }, // number
            { "123abc", false }, // number + letter
            { "abcabc", true },  // letter
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsLetter(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsDigit()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "!@^&*=", false }, // Special character
            { "a23!@#", false }, // Special character + number + letter
            { "123123", true },  // number
            { "123abc", false }, // number + letter
            { "abcabc", false }, // letter
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsDigit(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsAlpha()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "!@^&*=", false }, // Special character
            { "a23!@#", false }, // Special character + number + letter
            { "123123", false }, // number
            { "123abc", true },  // number + letter
            { "abcabc", false }, // letter
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsAlpha(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsComplex()
    {
        var strMap = new Dictionary<string, bool>
        {
            { "!@^&*=", false }, // Special character
            { "a23!@#", true },  // Special character + number + letter
            { "123123", false }, // number
            { "123abc", false }, // number + letter
            { "abcabc", false }, // letter
        };

        foreach (var str in strMap)
        {
            var ok = Validator.IsComplex(str.Key);
            Assert.That(ok, Is.EqualTo(str.Value));
        }
    }

    [Test]
    public void TestIsIp()
    {
        var ipsMap = new Dictionary<string, bool>
        {
            { "192.168.0.1:80888", false },
            { "abc.123.abc.192", false },
            { "192.168.0.256", false },
            { "192.168.0.1", true },
            { "127.0.0.1", true },
            { "[2001:0db8:0000:0003:0000:8a2e:0370:7334]:8080", true },
            { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", true },
            { "2001:0db8:0000:0003:0000:8a2e:0370:7334:8000", true },
        };

        foreach (var ip in ipsMap)
        {
            var ok = Validator.IsIp(ip.Key);
            Assert.That(ok, Is.EqualTo(ip.Value));
        }
    }
}
