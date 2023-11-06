namespace Mojito.SimpleLogging.Test
{
    public class LogHelperTest
    {
        [Test]
        public void TestConsoleLogger()
        {
            var message = "Hello World!";
            LogHelper.Info(message);
        }

        [Test]
        public void TestFileLogger()
        {
            var message = "Hello World!";
            LogHelper.Warn(message);

            var result = File.ReadAllText("Mojito.log");
            Assert.That(result.Trim(), Is.EqualTo(message));
        }
    }
}