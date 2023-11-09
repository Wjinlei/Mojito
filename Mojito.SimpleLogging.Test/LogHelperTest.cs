namespace Mojito.SimpleLogging.Test
{
    public class LogHelperTest
    {
        [Test]
        public void TestConsoleLogger()
        {
            var message = "Test ConsoleLogger";
            LogHelper.Info(message);
        }

        [Test]
        public void TestFileLogger()
        {
            var message = "Test FileLogger";
            LogHelper.Info(message);

            var result = File.ReadAllText("Mojito.log");
            TestContext.Out.Write(result);
        }
    }
}