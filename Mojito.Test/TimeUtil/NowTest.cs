using Mojito.TimeUtil;

namespace Mojito.Test.TimeUtil;

public class NowTest
{
    [Test]
    public void TestGetYear()
    {
        var sysYear = System.DateTime.Now.ToString("yyyy");
        var myYear = Now.GetYear();
        Assert.That(myYear, Is.EqualTo(sysYear));
    }

    [Test]
    public void TestGetMonth()
    {
        var sysMonth = System.DateTime.Now.ToString("MM");
        var myMonth = Now.GetMonth();
        Assert.That(myMonth, Is.EqualTo(sysMonth));
    }

    [Test]
    public void TestGetDay()
    {
        var sysDay = System.DateTime.Now.ToString("dd");
        var myDay = Now.GetDay();
        Assert.That(myDay, Is.EqualTo(sysDay));
    }

    [Test]
    public void TestGetHour()
    {
        var sysHour = System.DateTime.Now.ToString("HH");
        var myHour = Now.GetHour();
        Assert.That(myHour, Is.EqualTo(sysHour));
    }

    [Test]
    public void TestGetMinute()
    {
        var sysMinute = System.DateTime.Now.ToString("mm");
        var myMinute = Now.GetMinute();
        Assert.That(myMinute, Is.EqualTo(sysMinute));
    }

    [Test]
    public void TestGetSecond()
    {
        var sysSecond = System.DateTime.Now.ToString("ss");
        var mySecond = Now.GetSecond();
        Assert.That(mySecond, Is.EqualTo(sysSecond));
    }

    [Test]
    public void TestGetTime()
    {
        var sysTime = System.DateTime.Now.ToString("HH:mm:ss");
        var myTime = Now.GetTime();
        Assert.That(myTime, Is.EqualTo(sysTime));
    }

    [Test]
    public void TestGetDate()
    {
        var sysDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        var myDate = Now.GetDate();
        Assert.That(myDate, Is.EqualTo(sysDate));
    }

    [Test]
    public void TestGetDateTime()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var myDateTime = Now.GetDateTime();
        Assert.That(myDateTime, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestFormat()
    {
        var timeFormat = "yyyy/MM/dd HH:mm:ss";
        var sysDateTime = System.DateTime.Now.ToString(timeFormat);
        var myDateTime = Now.Format(timeFormat);
        Assert.That(myDateTime, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestGetUnixTimestamp()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var timestamp = Now.GetUnixTimestamp();
        TestContext.Out.WriteLine(timestamp);
        var temp = TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local);
        var myDateTime = temp.AddSeconds(timestamp).ToString("yyyy-MM-dd HH:mm:ss");
        Assert.That(myDateTime, Is.EqualTo(sysDateTime));
    }
}
