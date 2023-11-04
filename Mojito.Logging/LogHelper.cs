namespace Mojito.Logging;

public static class LogHelper
{
    private static Logger? logger;

    private static void Log(LogLevel level, LogTarget target, string message)
    {
        switch (target)
        {
            case LogTarget.Console:
                logger = new ConsoleLogger();
                break;
            case LogTarget.File:
                logger = new FileLogger();
                break;
            default:
                throw new NotSupportedException("Unsupported target");
        }

        switch (level)
        {
            case LogLevel.Debug:
                logger.Debug(message);
                break;
            case LogLevel.Info:
                logger.Info(message);
                break;
            case LogLevel.Warn:
                logger.Warn(message);
                break;
            case LogLevel.Error:
                logger.Error(message);
                break;
            case LogLevel.Fatal:
                logger.Fatal(message);
                break;
            default:
                return;
        }
    }

    public static void Debug(LogTarget target, string message)
    {
        Log(LogLevel.Debug, target, message);
    }

    public static void Info(LogTarget target, string message)
    {
        Log(LogLevel.Info, target, message);
    }

    public static void Warn(LogTarget target, string message)
    {
        Log(LogLevel.Warn, target, message);
    }

    public static void Error(LogTarget target, string message)
    {
        Log(LogLevel.Error, target, message);
    }

    public static void Fatal(LogTarget target, string message)
    {
        Log(LogLevel.Fatal, target, message);
    }
}
