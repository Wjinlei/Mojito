namespace Mojito.SimpleLogging.Loggers;

public class FileLogger : Logger
{
    private readonly string logFile;
    private readonly int maxLogFile = 0;
    private readonly int maxLogSize = 0;

    public FileLogger(string path, string maxSizeRollBackups, string maximumFileSize)
    {
        logFile = path;
        _ = int.TryParse(maxSizeRollBackups, out maxLogFile);
        _ = int.TryParse(maximumFileSize, out maxLogSize);
    }

    private static string GetMessage(string level, string message, string pattern)
    {
        return pattern.Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("%level", level)
            .Replace("%message", message)
            .Replace("%newline", Environment.NewLine);
    }

    public override void Debug(string message, string pattern)
    {
        CheckRollingBySize(pattern);
        var newMessage = GetMessage("Debug", message, pattern);
        File.AppendAllText(logFile, newMessage);
    }

    public override void Info(string message, string pattern)
    {
        CheckRollingBySize(pattern);
        var newMessage = GetMessage("Info", message, pattern);
        File.AppendAllText(logFile, newMessage);
    }

    public override void Warn(string message, string pattern)
    {
        CheckRollingBySize(pattern);
        var newMessage = GetMessage("Warn", message, pattern);
        File.AppendAllText(logFile, newMessage);
    }

    public override void Error(string message, string pattern)
    {
        CheckRollingBySize(pattern);
        var newMessage = GetMessage("Error", message, pattern);
        File.AppendAllText(logFile, newMessage);
    }

    public override void Fatal(string message, string pattern)
    {
        CheckRollingBySize(pattern);
        var newMessage = GetMessage("Fatal", message, pattern);
        File.AppendAllText(logFile, newMessage);
    }

    /// <summary>
    /// 按文件大小进行滚动
    /// </summary>
    /// <param name="pattern">日志的格式</param>
    private void CheckRollingBySize(string pattern)
    {
        var file = new FileInfo(logFile);
        if (!file.Exists)
            return;

        var fileSizeInBytes = file.Length;
        var fileSizeInKB = fileSizeInBytes / 1024;

        if (maxLogSize != 0 && fileSizeInKB > maxLogSize)
        {
            var index = 1;
            var indexFile = "Log.Index";

            try
            {
                var strIndex = File.ReadAllText(indexFile);
                index = int.Parse(strIndex);
            }
            catch
            {
                // 吞掉这个异常
            }

            try
            {
                if (index > maxLogFile && maxLogFile != 0)
                    File.Delete($"{logFile}.{index - maxLogFile}");
            }
            catch (Exception ex)
            {
                var newMessage = GetMessage("Warn", ex.StackTrace ?? ex.Message, pattern);
                File.AppendAllText(logFile, newMessage);
            }

            var backup = $"{logFile}.{index}";

            try
            {
                File.Move(logFile, backup);
                using var fileStream = File.Create(logFile);
                File.WriteAllText(indexFile, (++index).ToString());
            }
            catch (Exception ex)
            {
                var newMessage = GetMessage("Error", ex.StackTrace ?? ex.Message, pattern);
                File.AppendAllText(logFile, newMessage);
            }
        }
    }
}
