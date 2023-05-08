namespace Mojito.Test.Convert;

public class StringTest
{
    [Test]
    public void TestToInt16OrDefault()
    {
        var number1 = Mojito.Convert.String.ToInt16OrDefault("8080", 80);
        Assert.That(number1, Is.EqualTo(8080));

        var number2 = Mojito.Convert.String.ToInt16OrDefault("aa", 80);
        Assert.That(number2, Is.EqualTo(80));
    }

    [Test]
    public void TestToInt32OrDefault()
    {
        var number1 = Mojito.Convert.String.ToInt32OrDefault("8080", 80);
        Assert.That(number1, Is.EqualTo(8080));

        var number2 = Mojito.Convert.String.ToInt32OrDefault("aa", 80);
        Assert.That(number2, Is.EqualTo(80));
    }

    [Test]
    public void TestToInt64OrDefault()
    {
        var number1 = Mojito.Convert.String.ToInt64OrDefault("8080", 80);
        Assert.That(number1, Is.EqualTo(8080));

        var number2 = Mojito.Convert.String.ToInt64OrDefault("aa", 80);
        Assert.That(number2, Is.EqualTo(80));
    }
}
