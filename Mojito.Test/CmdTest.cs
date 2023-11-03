namespace Mojito.Test;

public class CmdTest
{
    [Test]
    public void TestExec()
    {
        var result = Cmd.Execute(@"netstat -ano");
        TestContext.Out.WriteLine(result.Output);
    }
}
