namespace Mojito.Test.Convert;

public class EncodingTest
{
    [Test]
    public void TestUtf8GetBytes()
    {
        var bytes = Mojito.Convert.Encoding.Utf8GetBytes("Hello 中国!");
        Assert.That(bytes, Is.EqualTo(
            new byte[] { 72, 101, 108, 108, 111, 32, 228, 184, 173, 229, 155, 189, 33 }));
    }

    [Test]
    public void TestUtf8()
    {
        var text = Mojito.Convert.Encoding.Utf8(
            new byte[] { 72, 101, 108, 108, 111, 32, 228, 184, 173, 229, 155, 189, 33 });
        Assert.That(text, Is.EqualTo("Hello 中国!"));
    }

    [Test]
    public void TestGbkGetBytes()
    {

        var bytes = Mojito.Convert.Encoding.GbkGetBytes("Hello 中国!");
        Assert.That(bytes, Is.EqualTo(
            new byte[] { 72, 101, 108, 108, 111, 32, 214, 208, 185, 250, 33 }));
    }

    [Test]
    public void TestGbk()
    {
        var text = Mojito.Convert.Encoding.Gbk(
            new byte[] { 72, 101, 108, 108, 111, 32, 214, 208, 185, 250, 33 });
        Assert.That(text, Is.EqualTo("Hello 中国!"));
    }

    [Test]
    public void TestUtf8ToGbk()
    {
        var result = Mojito.Convert.Encoding.Utf8ToGbk(
            new byte[] { 72, 101, 108, 108, 111, 32, 228, 184, 173, 229, 155, 189, 33 });
        Assert.That(result.Success, Is.True);
        var text = Mojito.Convert.Encoding.Gbk(result.GetOk());
        Assert.That(text, Is.EqualTo("Hello 中国!"));
    }

    [Test]
    public void TestGbkToUtf8()
    {
        var result = Mojito.Convert.Encoding.GbkToUtf8(
            new byte[] { 72, 101, 108, 108, 111, 32, 214, 208, 185, 250, 33 });
        Assert.That(result.Success, Is.True);
        var text = Mojito.Convert.Encoding.Utf8(result.GetOk());
        Assert.That(text, Is.EqualTo("Hello 中国!"));
    }
}
