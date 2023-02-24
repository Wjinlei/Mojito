namespace TestMojito.DateTime;

public class TimestampTest
{
    [Test]
    public void TestToHour()
    {
        var sysDateTime = System.DateTime.Now.ToString("HH");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToHour(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToMinute()
    {
        var sysDateTime = System.DateTime.Now.ToString("mm");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToMinute(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToSecond()
    {
        var sysDateTime = System.DateTime.Now.ToString("ss");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToSecond(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToTime()
    {
        var sysDateTime = System.DateTime.Now.ToString("HH:mm:ss");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToTime(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToYear()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToYear(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToMonth()
    {
        var sysDateTime = System.DateTime.Now.ToString("MM");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToMonth(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToDay()
    {
        var sysDateTime = System.DateTime.Now.ToString("dd");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToDay(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToDate()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToDate(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestToDateTime()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.ToDateTime(timestamp);
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }

    [Test]
    public void TestParse()
    {
        var sysDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var timestamp = Mojito.DateTime.Now.GetUnixTimestamp();
        var result = Mojito.DateTime.Timestamp.Parse(timestamp, "yyyy-MM-dd HH:mm:ss");
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.GetOk(), Is.EqualTo(sysDateTime));
        });
    }
}
