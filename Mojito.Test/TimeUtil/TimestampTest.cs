using Mojito.TimeUtil;

namespace Mojito.Test.TimeUtil;

public class TimestampTest
{
    [Test]
    public void TestToHour()
    {
        var sysDateTime = DateTime.Now.ToString("HH");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToHour(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToMinute()
    {
        var sysDateTime = DateTime.Now.ToString("mm");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToMinute(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToSecond()
    {
        var sysDateTime = DateTime.Now.ToString("ss");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToSecond(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToTime()
    {
        var sysDateTime = DateTime.Now.ToString("HH:mm:ss");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToTime(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToYear()
    {
        var sysDateTime = DateTime.Now.ToString("yyyy");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToYear(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToMonth()
    {
        var sysDateTime = DateTime.Now.ToString("MM");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToMonth(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToDay()
    {
        var sysDateTime = DateTime.Now.ToString("dd");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToDay(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToDate()
    {
        var sysDateTime = DateTime.Now.ToString("yyyy-MM-dd");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToDate(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestToDateTime()
    {
        var sysDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.ToDateTime(timestamp);
        Assert.That(result, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestParse()
    {
        var sysDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var timestamp = Now.GetUnixTimestamp();
        var result = Timestamp.Parse(timestamp, "yyyy-MM-dd HH:mm:ss");
        Assert.That(result, Is.EqualTo(sysDateTime));
    }
}
