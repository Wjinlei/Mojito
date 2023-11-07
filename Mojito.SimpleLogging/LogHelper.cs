using Microsoft.Extensions.Configuration;
using Mojito.SimpleLogging.Loggers;

namespace Mojito.SimpleLogging;

public static class LogHelper
{
    private static readonly IConfigurationRoot configuration;

    private static string pattern;
    private static readonly ConsoleLogger consoleLogger;

    static LogHelper()
    {
        pattern = "";
        consoleLogger = new ConsoleLogger();

        configuration = new ConfigurationBuilder()
            .AddXmlFile("App.config", optional: true, reloadOnChange: true)
            .Build();
    }

    private static Logger? GetLogger(LogLevel currentLevel)
    {
        var target = configuration["logging:target:value"] ??= "File";
        var level = configuration["logging:level:value"] ??= "Info";
        var file = configuration["logging:file:value"] ??= "Mojito.log";
        var maxFile = configuration["logging:file:max"] ??= "";
        var rollSizeInKb = configuration["logging:file:rollSizeInKb"] ??= "";
        pattern = configuration["logging:pattern:value"] ??= "%date %level %message%newline";

        Logger logger = target.ToLower() switch
        {
            "console" => consoleLogger,
            "file" => new FileLogger(file, maxFile, rollSizeInKb), // 这里每次写日志都new一个对象我感觉不太好，得想办法优化下。
            _ => consoleLogger,
        };

        return level.ToLower() switch
        {
            "debug" => logger,
            "info" => currentLevel > LogLevel.Debug ? logger : null,
            "warn" => currentLevel > LogLevel.Info ? logger : null,
            "error" => currentLevel > LogLevel.Warn ? logger : null,
            "fatal" => currentLevel > LogLevel.Error ? logger : null,
            _ => logger,
        };
    }

    public static void Debug(string message)
    {
        GetLogger(LogLevel.Debug)?.Debug(message, pattern);
    }

    public static void Info(string message)
    {
        GetLogger(LogLevel.Info)?.Info(message, pattern);
    }

    public static void Warn(string message)
    {
        GetLogger(LogLevel.Warn)?.Warn(message, pattern);
    }

    public static void Error(string message)
    {
        GetLogger(LogLevel.Error)?.Error(message, pattern);
    }

    public static void Fatal(string message)
    {
        GetLogger(LogLevel.Fatal)?.Fatal(message, pattern);
    }
}
