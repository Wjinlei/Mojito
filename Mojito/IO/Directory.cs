namespace Mojito.IO;

public static class Directory
{
    /// <summary>
    /// Creates all the directories in a specified path.
    /// </summary>
    /// <param name="path">The directory to create.</param>
    /// <returns></returns>
    public static Result Create(string path)
    {
        try
        {
            System.IO.Directory.CreateDirectory(path);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Creates the parent directory of the specified path
    /// </summary>
    /// <param name="path">The parent directory to create.</param>
    /// <returns></returns>
    public static Result CreateParent(string path)
    {
        try
        {
            System.IO.Directory.GetParent(path)?.Create();
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Creates a directory symbolic link identified by path that points to pathToTarget.
    /// </summary>
    /// <param name="path">The path where the symbolic link should be created.</param>
    /// <param name="pathToTarget">The target directory of the symbolic link.</param>
    /// <returns></returns>
    public static Result CreateSymbolicLink(string path, string pathToTarget)
    {
        try
        {
            System.IO.Directory.CreateSymbolicLink(path, pathToTarget);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Deletes an empty directory from a specified path.
    /// </summary>
    /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
    /// <returns></returns>
    public static Result Delete(string path)
    {
        return Delete(path, false);
    }

    /// <summary>
    /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
    /// </summary>
    /// <param name="path">The name of the directory to remove.</param>
    /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false.</param>
    /// <returns></returns>
    public static Result Delete(string path, bool recursive)
    {
        try
        {
            System.IO.Directory.Delete(path, recursive);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Moves a file or a directory and its contents to a new location.
    /// </summary>
    /// <param name="srcPath">The path of the file or directory to move.</param>
    /// <param name="destPath">The path to the new location for sourceDirName or its contents. If sourceDirName is a file, then destDirName must also be a file name.</param>
    /// <returns></returns>
    public static Result Move(string srcPath, string destPath)
    {
        try
        {
            System.IO.Directory.Move(srcPath, destPath);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Copy directories, but recursion is not supported
    /// </summary>
    /// <param name="srcPath">The path of the file or directory to copy.</param>
    /// <param name="destPath">The target path to copy to</param>
    /// <returns></returns>
    public static Result Copy(string srcPath, string destPath)
    {
        return Copy(srcPath, destPath, false);
    }

    /// <summary>
    /// Copy directories, but recursion is supported
    /// </summary>
    /// <param name="srcPath">The path of the file or directory to copy.</param>
    /// <param name="destPath">The target path to copy to</param>
    /// <param name="recursive">Recursive copy or not</param>
    /// <returns></returns>
    public static Result Copy(string srcPath, string destPath, bool recursive)
    {
        try
        {
            // 获取原目录信息
            var srcDir = new DirectoryInfo(srcPath);
            if (!srcDir.Exists)
                return Result.Error(new DirectoryNotFoundException("srcPath not found."));

            // 获取原目录中的子目录
            var srcSubDirs = srcDir.GetDirectories();

            // 创建目标目录
            System.IO.Directory.CreateDirectory(destPath);

            // 将原目录中的文件复制到目标目录中
            foreach (var srcFile in srcDir.GetFiles())
            {
                var targetFilePath = Path.Combine(destPath, srcFile.Name);
                srcFile.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                // 遍历原目录中的子目录并递归调用自身复制目录下的文件到目标目录
                foreach (var subDir in srcSubDirs)
                {
                    var destDir = Path.Combine(destPath, subDir.Name);
                    var result = Copy(subDir.FullName, destDir, true);
                    if (!result.Success)
                        return result;
                }
            }

            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
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
