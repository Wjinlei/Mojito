using Microsoft.Extensions.Configuration;
using Mojito.SimpleLogging.Loggers;

namespace Mojito.SimpleLogging;

public static class LogHelper
{
    private static readonly IConfigurationRoot configuration;

    private static readonly ConsoleLogger consoleLogger;

    static LogHelper()
    {
        consoleLogger = new ConsoleLogger();

        configuration = new ConfigurationBuilder()
            .AddXmlFile("App.config", optional: true, reloadOnChange: true)
            .Build();
    }

    private static Logger? GetLogger(LogLevel currentLevel)
    {
        var target = configuration["logging:target"];
        var level = configuration["logging:level"];
        var file = configuration["logging:file"];
        file ??= "Mojito.log";

        Logger logger = target switch
        {
            "Console" => consoleLogger,
            "File" => new FileLogger(file), // 这里每次写日志都new一个对象我感觉不太好，得想办法优化下。
            _ => consoleLogger,
        };

        return level switch
        {
            "Debug" => logger,
            "Info" => currentLevel > LogLevel.Debug ? logger : null,
            "Warn" => currentLevel > LogLevel.Info ? logger : null,
            "Error" => currentLevel > LogLevel.Warn ? logger : null,
            "Fatal" => currentLevel > LogLevel.Error ? logger : null,
            _ => logger,
        };
    }

    public static void Debug(string message)
    {
        GetLogger(LogLevel.Debug)?.Debug(message);
    }

    public static void Info(string message)
    {
        GetLogger(LogLevel.Info)?.Info(message);
    }

    public static void Warn(string message)
    {
        GetLogger(LogLevel.Warn)?.Warn(message);
    }

    public static void Error(string message)
    {
        GetLogger(LogLevel.Error)?.Error(message);
    }

    public static void Fatal(string message)
    {
        GetLogger(LogLevel.Fatal)?.Fatal(message);
    }
}
