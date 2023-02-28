namespace TestMojito;

public class CmdTest
{
    [Test]
    public void TestExec()
    {
        var result = Mojito.Cmd.Execute(@"netstat -ano");
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);

        Assert.That(result.Success, Is.True);
        TestContext.Out.WriteLine(result.GetOk());
    }
}
