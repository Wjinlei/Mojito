﻿namespace Mojito.Test;

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
    public void TestIsURL()
    {
        var urls = new[] {
            "http://xn--fiqs8s.cn",
            "http://example.com",
            "http://qq.com",
            "file://example.test.cn",
            "ftp://6.cn",
            "https://test.co.net",
            "https://example.com/login.php",
            "https://example.com/admin/login.php",
        };

        foreach (var url in urls)
        {
            var ok = Validator.IsURL(url);
            Assert.That(ok, Is.True);
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

    [Test]
    public void TestIsIPV4()
    {
        var ipsMap = new Dictionary<string, bool>
        {
            { "127.0.0.1", true },
            { "127.0.0.1:8080", true },
            { "10.35.10.253", true },
            { "10.35.10.253:8888", true },
            { "192.168.0.1", true },
            { "abc.123.abc.192", false },
            { "192.168.0.1000", false },
            { "192.168.0.256", false },
            { "1192.168.0.256", false },
            { "192.168.0.1:80888", false },
        };

        foreach (var ip in ipsMap)
        {
            var ok = Validator.IsIPV4(ip.Key);
            Assert.That(ok, Is.EqualTo(ip.Value));
        }
    }

    [Test]
    public void TestIsIPV6()
    {
        var ipsMap = new Dictionary<string, bool>
        {
            { "2001:0db8:85a3:0000:0000:8a2e:0370:7334", true },
            { "2001:0db8:0000:0003:0000:8a2e:0370:7334", true },
            { "[2001:0db8:0000:0003:0000:8a2e:0370:7334]:8080", true },
        };

        foreach (var ip in ipsMap)
        {
            var ok = Validator.IsIPV6(ip.Key);
            Assert.That(ok, Is.EqualTo(ip.Value));
        }
    }

    [Test]
    public void TestIsPhoneNumber()
    {
        var phoneNumbers = new[] {
            "19119255642",
            "17888829981",
            "18311006933",
        };

        foreach (var phoneNumber in phoneNumbers)
        {
            var ok = Validator.IsPhoneNumber(phoneNumber);
            Assert.That(ok, Is.True);
        }
    }
}
