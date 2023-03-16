namespace Mojito.Test.Random;

public class DateTimeTest
{
    [Test]
    public void TestCreate()
    {
        var myDateTime = Mojito.Random.DateTime.Create();
        TestContext.Out.WriteLine(myDateTime.ToString("yyyy-MM-dd hh:mm:ss"));

        Assert.Multiple(() =>
        {
            Assert.That(myDateTime.Year, Is.LessThanOrEqualTo(System.DateTime.Now.Year));
            Assert.That(myDateTime.Month, Is.LessThanOrEqualTo(System.DateTime.Now.Month));
            Assert.That(myDateTime.Day, Is.LessThanOrEqualTo(System.DateTime.Now.Day));
        });
    }
}
