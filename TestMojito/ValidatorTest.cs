namespace TestMojito;

public class ValidatorTest
{
    [Test]
    public void TestIsEmail()
    {
        var ok = Mojito.Validator.IsEmail("service@adm.net");
        Assert.That(ok, Is.True);
    }
}
