namespace TestMojito.DateTime;

public class NowTest
{
    [Test]
    public void TestGetYear()
    {
        var sysYear = System.DateTime.Now.ToString("yyyy");
        var myYear = Mojito.DateTime.Now.GetYear();
        Assert.That(myYear, Is.EqualTo(sysYear));
    }

    [Test]
    public void TestGetMonth()
    {
        var sysMonth = System.DateTime.Now.ToString("MM");
        var myMonth = Mojito.DateTime.Now.GetMonth();
        Assert.That(myMonth, Is.EqualTo(sysMonth));
    }

    [Test]
    public void TestGetDay()
    {
        var sysDay = System.DateTime.Now.ToString("dd");
        var myDay = Mojito.DateTime.Now.GetDay();
        Assert.That(myDay, Is.EqualTo(sysDay));
    }

    [Test]
    public void TestGetHour()
    {
        var sysHour = System.DateTime.Now.ToString("HH");
        var myHour = Mojito.DateTime.Now.GetHour();
        Assert.That(myHour, Is.EqualTo(sysHour));
    }

    [Test]
    public void TestGetMinute()
    {
        var sysMinute = System.DateTime.Now.ToString("mm");
        var myMinute = Mojito.DateTime.Now.GetMinute();
        Assert.That(myMinute, Is.EqualTo(sysMinute));
    }

    [Test]
    public void TestGetSecond()
    {
        var sysSecond = System.DateTime.Now.ToString("ss");
        var mySecond = Mojito.DateTime.Now.GetSecond();
        Assert.That(mySecond, Is.EqualTo(sysSecond));
    }

    [Test]
    public void TestGetTime()
    {
        var sysTime = System.DateTime.Now.ToString("HH:mm:ss");
        var myTime = Mojito.DateTime.Now.GetTime();
        Assert.That(myTime, Is.EqualTo(sysTime));
    }

    [Test]
    public void TestGetDate()
    {
        var sysDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        var myDate = Mojito.DateTime.Now.GetDate();
        Assert.That(myDate, Is.EqualTo(sysDate));
    }

    [Test]
    public void TestGetDateTime()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var myDateTime = Mojito.DateTime.Now.GetDateTime();
        Assert.That(myDateTime, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestFormat()
    {
        var timeFormat = "yyyy/MM/dd HH:mm:ss";
        var sysDateTime = System.DateTime.Now.ToString(timeFormat);
        var myDateTime = Mojito.DateTime.Now.Format(timeFormat);
        Assert.That(myDateTime, Is.EqualTo(sysDateTime));
    }

    [Test]
    public void TestGetUnixTimestamp()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        TestContext.Out.WriteLine(timestamp);
        var temp = TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local);
        var myDateTime = temp.AddSeconds(timestamp).ToString("yyyy-MM-dd HH:mm:ss");
        Assert.That(myDateTime, Is.EqualTo(sysDateTime));
    }
}
