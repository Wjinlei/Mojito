using System.Diagnostics;

namespace Mojito;

public static class Cmd
{
    /// <summary>
    /// Execute a command
    /// </summary>
    /// <param name="cmd">Command text</param>
    /// <returns></returns>
    public static Result<string> Execute(string cmd)
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
                return Result<string>.Error(
                    new PlatformNotSupportedException(
                        $"Unsupported operating system: {Environment.OSVersion}."));
        }

        compiler.StartInfo.RedirectStandardInput = true;
        compiler.StartInfo.RedirectStandardOutput = true;
        compiler.StartInfo.RedirectStandardError = true;
        compiler.StartInfo.CreateNoWindow = true;

        try
        {
            compiler.StartInfo.UseShellExecute = false; // UWP is set to true PlatformNotSupportedException will happen
            compiler.Start();
            compiler.StandardInput.WriteLine(cmd + "&exit");
            compiler.StandardInput.AutoFlush = true;

            var output = compiler.StandardOutput.ReadToEnd();
            var error = compiler.StandardError.ReadToEnd();

            compiler.WaitForExit();
            if (error != "")
                return Result<string>.Error(new Exception(error));
            return Result<string>.Ok(output);
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex);
        }
    }
}
