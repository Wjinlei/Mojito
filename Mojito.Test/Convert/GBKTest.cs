using Mojito.Convert;

namespace Mojito.Test.Convert;

public class GBKTest
{
    [Test]
    public void TestGbkToUtf8()
    {
        var utf8Bytes = new byte[] { 72, 101, 108, 108, 111, 32, 228, 184, 173, 229, 155, 189, 33 };

        var result = GBK.GbkToUtf8(new byte[] { 72, 101, 108, 108, 111, 32, 214, 208, 185, 250, 33 });

        Assert.That(result, Is.EqualTo(utf8Bytes));
    }
}
