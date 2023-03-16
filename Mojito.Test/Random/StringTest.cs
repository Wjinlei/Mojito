namespace Mojito.Test.Random;

public class StringTest
{
    [Test]
    public void TestLetters()
    {
        var randomLetters = Mojito.Random.String.Letters(10);
        TestContext.Out.WriteLine(randomLetters);
        Assert.That(randomLetters, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestNumbers()
    {
        var randomNumbers = Mojito.Random.String.Numbers(10);
        TestContext.Out.WriteLine(randomNumbers);
        Assert.That(randomNumbers, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestCombinationOfLettersAndNumbers()
    {
        var randomLettersAndNumbers = Mojito.Random.String.CombinationOfLettersAndNumbers(10);
        TestContext.Out.WriteLine(randomLettersAndNumbers);
        Assert.That(randomLettersAndNumbers, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestComplex()
    {
        var randomComplex = Mojito.Random.String.Complex(10);
        TestContext.Out.WriteLine(randomComplex);
        Assert.That(randomComplex, Has.Length.EqualTo(10));
    }

    [Test]
    public void TestCreate()
    {
        var result = Mojito.Random.String.Create("123abc", 10);
        TestContext.Out.WriteLine(result.GetOk());
        Assert.That(result.Success, Is.True);
    }
}
