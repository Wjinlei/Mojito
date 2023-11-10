namespace Mojito.PsUtil.Test;

public class LoadAvgTest
{
    [Test]
    public void TestLoadAvg()
    {
        TestContext.Out.WriteLine($"load average: {LoadAvg.LoadAvg01m}, {LoadAvg.LoadAvg05m}, {LoadAvg.LoadAvg15m}");
    }
}