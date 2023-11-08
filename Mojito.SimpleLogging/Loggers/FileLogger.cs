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

    private static string GetMessage(string level, string message, string pattern)
    {
        return pattern.Replace("%date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .Replace("%level", level)
            .Replace("%message", message)
            .Replace("%newline", Environment.NewLine);
    }

    public override void Debug(string message, string pattern)
    {
        CheckRolling(pattern);
        File.AppendAllText(logFile, GetMessage("Debug", message, pattern));
    }

    public override void Info(string message, string pattern)
    {
        CheckRolling(pattern);
        File.AppendAllText(logFile, GetMessage("Info", message, pattern));
    }

    public override void Warn(string message, string pattern)
    {
        CheckRolling(pattern);
        File.AppendAllText(logFile, GetMessage("Warn", message, pattern));
    }

    public override void Error(string message, string pattern)
    {
        CheckRolling(pattern);
        File.AppendAllText(logFile, GetMessage("Error", message, pattern));
    }

    public override void Fatal(string message, string pattern)
    {
        CheckRolling(pattern);
        File.AppendAllText(logFile, GetMessage("Fatal", message, pattern));
    }

    private void CheckRolling(string pattern)
    {
        var file = new FileInfo(logFile);
        if (!file.Exists)
            return;

        var fileSizeInBytes = file.Length;
        var fileSizeInKB = fileSizeInBytes / 1024;
        var timeDifference = DateTime.Now - file.CreationTime;

        if (rollMinutes != 0 && timeDifference.TotalMinutes > rollMinutes)
            Rolling(pattern);

        if (rollSizeInKb != 0 && fileSizeInKB > rollSizeInKb)
            Rolling(pattern);
    }

    private void Rolling(string pattern)
    {
        var now = DateTime.Now;
        try
        {
            if (rollBackups != 0)
                DeleteOldRollBackups(rollBackups);

            File.Move(logFile, $"{logFile}.{now:yyyy-MM-dd_HH-mm-ss}");
            File.Create(logFile).Close();
            File.SetCreationTime(logFile, now);
            File.SetLastWriteTime(logFile, now);
            File.SetLastAccessTime(logFile, now);
        }
        catch (Exception ex)
        {
            var newMessage = GetMessage("Error", ex.StackTrace ?? ex.Message, pattern);
            File.AppendAllText(logFile, newMessage);
        }
    }

    private void DeleteOldRollBackups(int maxRollBackups)
    {
        var backupDirectory = Path.GetDirectoryName(logFile);
        if (string.IsNullOrWhiteSpace(backupDirectory))
            backupDirectory = Environment.CurrentDirectory;

        var regexPattern = $@"^{Regex.Escape(logFile)}\..*";
        var files = Directory.GetFiles(backupDirectory).Where(f => Regex.IsMatch(Path.GetFileName(f), regexPattern)).ToArray();
        if (files == null)
            return;

        if (files.Length >= maxRollBackups)
        {
            Array.Sort(files, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

            for (int i = 0; i <= files.Length - maxRollBackups; i++)
            {
                File.Delete(files[i]);
            }
        }
    }
}
