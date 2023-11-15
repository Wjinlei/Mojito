namespace Mojito.IOUtil;

public static class Directory
{
    /// <summary>
    /// Recursively copy directories
    /// </summary>
    /// <param name="srcPath">The path of the file or directory to copy.</param>
    /// <param name="destPath">The target path to copy to</param>
    /// <returns></returns>
    public static void Copy(string srcPath, string destPath)
    {
        Copy(srcPath, destPath, true);
    }

    /// <summary>
    /// Copy directories, but recursion is supported
    /// </summary>
    /// <param name="srcPath">The path of the file or directory to copy.</param>
    /// <param name="destPath">The target path to copy to</param>
    /// <param name="recursive">Recursive copy or not</param>
    /// <returns></returns>
    public static void Copy(string srcPath, string destPath, bool recursive)
    {
        var srcDir = new DirectoryInfo(srcPath);
        if (!srcDir.Exists)
            throw new DirectoryNotFoundException($"{srcPath} not found.");

        var srcSubDirs = srcDir.GetDirectories();

        System.IO.Directory.CreateDirectory(destPath);

        foreach (var srcFile in srcDir.GetFiles())
        {
            var targetFilePath = Path.Combine(destPath, srcFile.Name);
            srcFile.CopyTo(targetFilePath);
        }

        if (recursive)
        {
            foreach (var subDir in srcSubDirs)
            {
                var destDir = Path.Combine(destPath, subDir.Name);
                Copy(subDir.FullName, destDir, true);
            }
        }
    }
}
