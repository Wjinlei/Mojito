namespace TestMojito.Random;

public class StringTest
{
    [Test]
    public void TestLetters()
    {
        var randomAlpha = Mojito.Random.String.Letters(10);
        TestContext.Out.WriteLine(randomAlpha);
        Assert.That(randomAlpha, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestNumbers()
    {
        var randomAlpha = Mojito.Random.String.Numbers(10);
        TestContext.Out.WriteLine(randomAlpha);
        Assert.That(randomAlpha, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestCombinationOfLettersAndNumbers()
    {
        var randomAlpha = Mojito.Random.String.CombinationOfLettersAndNumbers(10);
        TestContext.Out.WriteLine(randomAlpha);
        Assert.That(randomAlpha, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestComplex()
    {
        var randomAlpha = Mojito.Random.String.Complex(10);
        TestContext.Out.WriteLine(randomAlpha);
        Assert.That(randomAlpha, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestCreate()
    {
        var result = Mojito.Random.String.Create("123abc", 10);
        TestContext.Out.WriteLine(result.GetOk());
        Assert.That(result.Success, Is.True);
    }
}
