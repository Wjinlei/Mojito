namespace Mojito.IO;

public static class File
{
    /// <summary>
    /// Create file
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns></returns>
    public static Result Create(string path)
    {
        return Create(path, FileMode.CreateNew);
    }

    /// <summary>
    /// Create the file with FileMode
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="fileMode">File mode</param>
    /// <returns></returns>
    public static Result Create(string path, FileMode fileMode)
    {
        try
        {
            using var fs = new FileStream(path, fileMode);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Check whether the file exists
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns></returns>
    public static bool Exists(string path)
    {
        return System.IO.File.Exists(path);
    }
}
