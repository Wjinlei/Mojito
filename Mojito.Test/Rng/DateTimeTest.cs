namespace Mojito.Test.Rng;

public class DateTimeTest
{
    [Test]
    public void TestCreate()
    {
        var myDateTime = Mojito.Rng.DateTime.Create();
        TestContext.Out.WriteLine(myDateTime.ToString("yyyy-MM-dd hh:mm:ss"));
        Assert.Pass();
    }
}
