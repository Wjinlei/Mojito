namespace Mojito.IO;

public static class Directory
{
    /// <summary>
    /// Creates all the directories in a specified path.
    /// </summary>
    /// <param name="path">The directory to create.</param>
    /// <returns></returns>
    public static DirectoryInfo Create(string path)
    {
        return System.IO.Directory.CreateDirectory(path);
    }

    /// <summary>
    /// Creates the parent directory of the specified path
    /// </summary>
    /// <param name="path">The parent directory to create.</param>
    /// <returns></returns>
    public static void CreateParent(string path)
    {
        System.IO.Directory.GetParent(path)?.Create();
    }

    /// <summary>
    /// Creates a directory symbolic link identified by path that points to pathToTarget.
    /// </summary>
    /// <param name="path">The path where the symbolic link should be created.</param>
    /// <param name="pathToTarget">The target directory of the symbolic link.</param>
    /// <returns></returns>
    public static FileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
    {
        return System.IO.Directory.CreateSymbolicLink(path, pathToTarget);
    }

    /// <summary>
    /// Recursively delete directories
    /// </summary>
    /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
    /// <returns></returns>
    public static void Delete(string path)
    {
        Delete(path, true);
    }

    /// <summary>
    /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
    /// </summary>
    /// <param name="path">The name of the directory to remove.</param>
    /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false.</param>
    /// <returns></returns>
    private static void Delete(string path, bool recursive)
    {
        System.IO.Directory.Delete(path, recursive);
    }

    /// <summary>
    /// Moves a file or a directory and its contents to a new location.
    /// </summary>
    /// <param name="srcPath">The path of the file or directory to move.</param>
    /// <param name="destPath">The path to the new location for sourceDirName or its contents. If sourceDirName is a file, then destDirName must also be a file name.</param>
    /// <returns></returns>
    public static void Move(string srcPath, string destPath)
    {
        System.IO.Directory.Move(srcPath, destPath);
    }

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
            throw new DirectoryNotFoundException("srcPath not found.");

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

    /// <summary>
    /// Determines whether the given path refers to an existing directory on disk.
    /// </summary>
    /// <param name="path">The path to test.</param>
    /// <returns></returns>
    public static bool Exists(string path)
    {
        return System.IO.Directory.Exists(path);
    }
}
