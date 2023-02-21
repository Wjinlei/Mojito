using System.Text;

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
    /// Create Symbolic link
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="pathToTarget">Path to target</param>
    /// <returns></returns>
    public static Result CreateSymbolicLink(string path, string pathToTarget)
    {
        try
        {
            System.IO.File.CreateSymbolicLink(path, pathToTarget);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Delete file
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns></returns>
    public static Result Delete(string path)
    {
        try
        {
            System.IO.File.Delete(path);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Move files but do not overwrite them
    /// </summary>
    /// <param name="srcPath">Src path</param>
    /// <param name="newPath">New path</param>
    /// <returns></returns>
    public static Result Move(string srcPath, string newPath)
    {
        return Move(srcPath, newPath, false);
    }

    /// <summary>
    /// Move the file and optionally overwrite it if it already exists
    /// </summary>
    /// <param name="srcPath">Src path</param>
    /// <param name="newPath">New path</param>
    /// <returns></returns>
    public static Result Move(string srcPath, string newPath, bool overwrite)
    {
        try
        {
            System.IO.File.Move(srcPath, newPath, overwrite);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Copy files but do not overwrite them
    /// </summary>
    /// <param name="srcPath">Src path</param>
    /// <param name="newPath">New path</param>
    /// <returns></returns>
    public static Result Copy(string srcPath, string newPath)
    {
        return Copy(srcPath, newPath, false);
    }

    /// <summary>
    /// Copy the file and optionally overwrite it if it already exists
    /// </summary>
    /// <param name="srcPath">Src path</param>
    /// <param name="destPath">New path</param>
    /// <param name="overwrite">Is overwrite</param>
    /// <returns></returns>
    public static Result Copy(string srcPath, string destPath, bool overwrite)
    {
        try
        {
            System.IO.File.Copy(srcPath, destPath, overwrite);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Read the file with UTF8 encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns></returns>
    public static Result<string> ReadAllText(string path)
    {
        return ReadAllText(path, Encoding.UTF8);
    }

    /// <summary>
    /// Reads a file with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result<string> ReadAllText(string path, Encoding encoding)
    {
        try
        {
            var content = System.IO.File.ReadAllText(path, encoding);
            return Result<string>.Ok(content);
        }
        catch (Exception ex)
        {
            return Result<string>.Error(ex);
        }
    }

    /// <summary>
    /// Read file to iterator with UTF8 encoding
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Result<IEnumerable<string>> ReadLines(string path)
    {
        return ReadLines(path, Encoding.UTF8);
    }

    /// <summary>
    /// Reads a file into an iterator with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result<IEnumerable<string>> ReadLines(string path, Encoding encoding)
    {
        try
        {
            var enumerable = System.IO.File.ReadLines(path, encoding);
            return Result<IEnumerable<string>>.Ok(enumerable);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<string>>.Error(ex);
        }
    }

    /// <summary>
    /// Read file to string array with UTF8 encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns></returns>
    public static Result<string[]> ReadAllLines(string path)
    {
        return ReadAllLines(path, Encoding.UTF8);
    }

    /// <summary>
    /// Reads a file into an string array with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result<string[]> ReadAllLines(string path, Encoding encoding)
    {
        try
        {
            var array = System.IO.File.ReadAllLines(path, encoding);
            return Result<string[]>.Ok(array);
        }
        catch (Exception ex)
        {
            return Result<string[]>.Error(ex);
        }
    }

    /// <summary>
    /// Read the file to the byte array
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns></returns>
    public static Result<byte[]> ReadAllBytes(string path)
    {
        try
        {
            var array = System.IO.File.ReadAllBytes(path);
            return Result<byte[]>.Ok(array);
        }
        catch (Exception ex)
        {
            return Result<byte[]>.Error(ex);
        }
    }

    /// <summary>
    /// Write to file with UTF8 encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="contents">Content</param>
    /// <returns></returns>
    public static Result WriteAllText(string path, string contents)
    {
        return WriteAllText(path, contents, Encoding.UTF8);
    }

    /// <summary>
    /// Writes to a file with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="contents">Content</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result WriteAllText(string path, string contents, Encoding encoding)
    {
        try
        {
            System.IO.File.WriteAllText(path, contents, encoding);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Writes all lines to file with UTF8 encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="lines">Lines</param>
    /// <returns></returns>
    public static Result WriteAllLines(string path, string[] lines)
    {
        return WriteAllLines(path, lines, Encoding.UTF8);
    }

    /// <summary>
    /// Writes all lines to a file with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="lines">Lines</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result WriteAllLines(string path, string[] lines, Encoding encoding)
    {
        try
        {
            System.IO.File.WriteAllLines(path, lines, encoding);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Writes a byte array to a file
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="bytes">Byte array</param>
    /// <returns></returns>
    public static Result WriteAllBytes(string path, byte[] bytes)
    {
        try
        {
            System.IO.File.WriteAllBytes(path, bytes);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Append string to file with UTF8 encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="contents">Content</param>
    /// <returns></returns>
    public static Result AppendAllText(string path, string contents) 
    {
        return AppendAllText(path, contents, Encoding.UTF8);
    }

    /// <summary>
    /// Append a string to a file with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="contents">Content</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result AppendAllText(string path, string contents, Encoding encoding)
    {
        try
        {
            System.IO.File.AppendAllText(path, contents, encoding);
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Append all lines to the file with UTF8 encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="lines">Lines</param>
    /// <returns></returns>
    public static Result AppendAllLines(string path, string[] lines)
    {
        return AppendAllLines(path, lines, Encoding.UTF8);
    }

    /// <summary>
    /// Appends all lines to a file with the specified encoding
    /// </summary>
    /// <param name="path">File path</param>
    /// <param name="lines">Lines</param>
    /// <param name="encoding">Encoding</param>
    /// <returns></returns>
    public static Result AppendAllLines(string path, string[] lines, Encoding encoding)
    {
        try
        {
            System.IO.File.AppendAllLines(path, lines, encoding);
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
