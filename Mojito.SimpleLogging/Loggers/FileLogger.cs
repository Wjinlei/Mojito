using System.Text.RegularExpressions;

namespace Mojito.SimpleLogging.Loggers;

public class FileLogger : Logger
{
    private readonly string logFile;
    private readonly int rollBackups = 0;
    private readonly int rollSizeInKb = 0;
    private readonly int rollMinutes = 0;

    public FileLogger(string path, string maxRollBackups, string maxRollSize, string rollTimeInMinutes)
    {
        logFile = path;
        _ = int.TryParse(maxRollBackups, out rollBackups);
        _ = int.TryParse(maxRollSize, out rollSizeInKb);
        _ = int.TryParse(rollTimeInMinutes, out rollMinutes);
    }

    public override void WriteLog(string message)
    {
        CheckRolling();
        File.AppendAllText(logFile, message);
    }

    /// <summary>
    /// 检查是否需要滚动日志
    /// </summary>
    private void CheckRolling()
    {
        var file = new FileInfo(logFile);
        if (!file.Exists)
            return;

        var fileSizeInBytes = file.Length;
        var fileSizeInKB = fileSizeInBytes / 1024;
        var timeDifference = DateTime.Now - file.CreationTime;

        if ((rollMinutes != 0 && timeDifference.TotalMinutes > rollMinutes) ||
            (rollSizeInKb != 0 && fileSizeInKB > rollSizeInKb))
        {
            Rolling();
        }
    }

    /// <summary>
    /// 滚动日志
    /// </summary>
    private void Rolling()
    {
        var now = DateTime.Now;

        try
        {
            if (rollBackups != 0)
                DeleteOldRollBackups(rollBackups);

            File.Move(logFile, $"{logFile}.{now:yyyy-MM-dd_HH-mm-ss}");
            File.Create(logFile).Close();
            File.SetCreationTime(logFile, now);
        }
        catch (Exception ex)
        {
            var errorMessage = $"{now:yyyy-MM-dd_HH-mm-ss} RollError {ex.Message} {ex.StackTrace}{Environment.NewLine}";
            File.AppendAllText(logFile, errorMessage);
        }
    }

    /// <summary>
    /// 删除旧的滚动日志，保持最大滚动日志数量
    /// </summary>
    /// <param name="maxRollBackups">最大日志数量</param>
    private void DeleteOldRollBackups(int maxRollBackups)
    {
        var backupDirectory = Path.GetDirectoryName(logFile);
        if (string.IsNullOrWhiteSpace(backupDirectory))
            backupDirectory = Environment.CurrentDirectory;

        // 过滤日志备份文件
        var regexPattern = $@"^{Regex.Escape(logFile)}\..*";
        var files = Directory.GetFiles(backupDirectory)
            .Where(f => Regex.IsMatch(Path.GetFileName(f), regexPattern))
            .ToArray();

        if (files == null)
            return;

        if (files.Length >= maxRollBackups)
        {
            // 按创建时间排序
            Array.Sort(files, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

            for (int i = 0; i <= files.Length - maxRollBackups; i++)
            {
                File.Delete(files[i]);
            }
        }
    }
}
