namespace Mojito.Test.Convert;

public class TimeTest
{
    [Test]
    public void TestFormat()
    {
        var timeStr = "2023-11-15 14:27:42";
        var dateTime = DateTime.Parse(timeStr);
        var timestamp = new DateTimeOffset(dateTime).ToUnixTimeSeconds();

        var result = Mojito.Convert.Time.Format(timestamp, "yyyy-MM-dd HH:mm:ss");
        Assert.That(result, Is.EqualTo(timeStr));
    }

    [Test]
    public void TestToTimestamp()
    {
        var timeStr = "2023-11-15 14:27:42";
        var dateTime = DateTime.Parse(timeStr);
        var timestamp = new DateTimeOffset(dateTime).ToUnixTimeSeconds();

        var result = Mojito.Convert.Time.ToTimestamp(timeStr);
        Assert.That(result, Is.EqualTo(timestamp));
    }
}
