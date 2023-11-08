namespace Mojito.SimpleLogging.Loggers;

public class LoggerDecorator : Logger
{
    private readonly Logger logger;

    public LoggerDecorator(Logger logger)
    {
        this.logger = logger;
    }

    public override void Log(string message, LogLevel level)
    {
        var strLevel = level switch
        {
            LogLevel.Debug => "Debug",
            LogLevel.Info => "Info",
            LogLevel.Warn => "Warn",
            LogLevel.Error => "Error",
            LogLevel.Fatal => "Fatal",
            _ => "",
        };

        var newMessage = LogConfigHelper.GetLogPattern()
            .Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("%level", strLevel)
            .Replace("%message", message)
            .Replace("%newline", Environment.NewLine);

        logger.Log(newMessage, level);
    }
}
