using Mojito.Convert;

namespace Mojito.Test.Convert;

public class UTF8Test
{
    [Test]
    public void TestUtf8ToGbk()
    {
        var gbkBytes = new byte[] { 72, 101, 108, 108, 111, 32, 214, 208, 185, 250, 33 };

        var result = UTF8.Utf8ToGbk(new byte[] { 72, 101, 108, 108, 111, 32, 228, 184, 173, 229, 155, 189, 33 });

        Assert.That(result, Is.EqualTo(gbkBytes));
    }
}
