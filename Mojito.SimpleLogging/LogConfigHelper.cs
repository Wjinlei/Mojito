using Microsoft.Extensions.Configuration;

namespace Mojito.SimpleLogging;

public static class LogConfigHelper
{
    private static readonly IConfigurationRoot configuration;

    static LogConfigHelper()
    {
        configuration = new ConfigurationBuilder()
            .AddXmlFile("App.config", optional: true, reloadOnChange: true)
            .Build();
    }

    public static string GetLogPath()
    {
        return configuration["logging:target:file"] ??= "Mojito.log";
    }

    public static string GetLogTarget()
    {
        var target = configuration["logging:target:value"] ??= "Console";
        return target.ToLower();
    }

    public static string GetLogLevel()
    {
        var level = configuration["logging:level:value"] ??= "Debug";
        return level.ToLower();
    }

    public static string GetLogPattern()
    {
        return configuration["logging:pattern:value"] ??= "%date %level %message%newline";
    }

    public static int GetMaxRollBackups()
    {
        var maxRollBackups = configuration["logging:target:maxRollBackups"] ??= "0";
        _ = int.TryParse(maxRollBackups, out int result);
        return result;
    }

    public static int GetMaxRollSizeInKB()
    {
        var rollSizeInKb = configuration["logging:target:rollSizeInKb"] ??= "0";
        _ = int.TryParse(rollSizeInKb, out int result);
        return result;
    }

    public static int GetRollTimeInMinutes()
    {
        var rollTimeInMinutes = configuration["logging:target:rollTimeInMinutes"] ??= "0";
        _ = int.TryParse(rollTimeInMinutes, out int result);
        return result;
    }
}
