namespace Mojito.Test.Rng;

public class StringTest
{
    [Test]
    public void TestAlpha()
    {
        var randomAlpha = Mojito.Rng.String.Alpha(10);
        TestContext.Out.WriteLine(randomAlpha);
        Assert.That(randomAlpha, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestAlphaNumber()
    {
        var randomAlphaNumber = Mojito.Rng.String.AlphaNumber(10);
        TestContext.Out.WriteLine(randomAlphaNumber);
        Assert.That(randomAlphaNumber, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestNumber()
    {
        var randomNumber = Mojito.Rng.String.Number(10);
        TestContext.Out.WriteLine(randomNumber);
        Assert.That(randomNumber, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestComplex()
    {
        var randomComplex = Mojito.Rng.String.Complex(10);
        TestContext.Out.WriteLine(randomComplex);
        Assert.That(randomComplex, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestCreate()
    {
        var result = Mojito.Rng.String.Create("123abc", 10);
        TestContext.Out.WriteLine(result);
        Assert.That(result, Has.Length.EqualTo(10));
    }
}
