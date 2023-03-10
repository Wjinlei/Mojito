using System.Text;

namespace TestMojito;

public class ConvertTest
{
    [Test]
    public void TestUTF8ToGBK1()
    {
        // GBK:  72,101,108,108,111,32,214,208,185,250,33
        // UTF8: 72,101,108,108,111,32,228,184,173,229,155,189,33
        var bytes = new byte[] { 72, 101, 108, 108, 111, 32, 228, 184, 173, 229, 155, 189, 33 };

        var result = Mojito.Convert.UTF8ToGBK(Encoding.UTF8.GetString(bytes));
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo("Hello 中国!"));
        });
    }

    [Test]
    public void TestUTF8ToGBK2()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var gbk = Encoding.GetEncoding("GBK");
        var gbkBytes = gbk.GetBytes("Hello 中国!");
        var utf8Bytes = Encoding.UTF8.GetBytes("Hello 中国!");
        var result = Mojito.Convert.UTF8ToGBK(utf8Bytes);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(gbkBytes));
        });
    }

    [Test]
    public void TestGBKToUTF81()
    {
        // GBK:  72,101,108,108,111,32,214,208,185,250,33
        // UTF8: 72,101,108,108,111,32,228,184,173,229,155,189,33
        var bytes = new byte[] { 72, 101, 108, 108, 111, 32, 214, 208, 185, 250, 33 };
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        var result = Mojito.Convert.GBKToUTF8(Encoding.GetEncoding("GBK").GetString(bytes));
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo("Hello 中国!"));
        });
    }

    [Test]
    public void TestGBKToUTF82()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var gbk = Encoding.GetEncoding("GBK");
        var gbkBytes = gbk.GetBytes("Hello 中国!");
        var utf8Bytes = Encoding.UTF8.GetBytes("Hello 中国!");
        var result = Mojito.Convert.GBKToUTF8(gbkBytes);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(utf8Bytes));
        });
    }

    [Test]
    public void TestHexToBytes()
    {
        var hex = "25EB8D9F60D78F95486D103234AEBF09";
        var bytes = Mojito.Convert.HexToBytes(hex);
        Assert.That(bytes, Is.EqualTo(new byte[] { 37, 235, 141, 159, 96, 215, 143, 149, 72, 109, 16, 50, 52, 174, 191, 9 }));
    }
}
