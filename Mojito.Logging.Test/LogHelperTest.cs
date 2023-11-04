namespace Mojito.Logging.Test
{
    public class LogHelperTest
    {
        [Test]
        public void TestConsoleLogger()
        {
            var message = "Hello World!";
            LogHelper.Info(LogTarget.Console, message);
        }

        [Test]
        public void TestFileLogger()
        {
            var message = "Hello World!";
            LogHelper.Info(LogTarget.File, message);

            var result = File.ReadAllText("log.txt");
            Assert.That(result.Trim(), Is.EqualTo(message));
        }
    }
}