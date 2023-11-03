using System.Diagnostics;

namespace Mojito;

public class CmdResult
{
    public string Output;
    public string Error;

    public CmdResult(string output, string error)
    {
        Output = output;
        Error = error;
    }
}

public static class Cmd
{
    /// <summary>
    /// Execute a command
    /// </summary>
    /// <param name="cmd">Command text</param>
    /// <returns></returns>
    /// <exception cref="PlatformNotSupportedException"></exception>
    public static CmdResult Execute(string cmd)
    {
        using var compiler = new Process();

        switch (Environment.OSVersion.Platform)
        {
            case PlatformID.Win32NT:
                compiler.StartInfo.FileName = "cmd.exe";
                break;
            case PlatformID.Unix:
                compiler.StartInfo.FileName = "bash";
                break;
            default:
                throw new PlatformNotSupportedException(
                        $"Unsupported operating system: {Environment.OSVersion}.");
        }

        compiler.StartInfo.RedirectStandardInput = true;
        compiler.StartInfo.RedirectStandardOutput = true;
        compiler.StartInfo.RedirectStandardError = true;
        compiler.StartInfo.CreateNoWindow = true;


        compiler.StartInfo.UseShellExecute = false; // UWP is set to true PlatformNotSupportedException will happen
        compiler.Start();
        compiler.StandardInput.WriteLine(cmd + "&exit");
        compiler.StandardInput.AutoFlush = true;

        var output = compiler.StandardOutput.ReadToEnd();
        var error = compiler.StandardError.ReadToEnd();

        compiler.WaitForExit();

        return new CmdResult(output, error);
    }
}
