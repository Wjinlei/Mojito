namespace Mojito.IO;

public static class File
{
    /// <summary>
    /// Create file
    /// </summary>
    /// <param name="path">The path and name of the file to create.</param>
    /// <returns></returns>
    public static FileStream Create(string path)
    {
        return Create(path, FileMode.CreateNew);
    }

    /// <summary>
    /// Create file with the specified path and creation mode.
    /// </summary>
    /// <param name="path">The path and name of the file to create.</param>
    /// <param name="fileMode">One of the enumeration values that determines how to open or create the file. <see cref="FileMode"/></param>
    /// <returns></returns>
    public static FileStream Create(string path, FileMode fileMode)
    {
        return new FileStream(path, fileMode);
    }

    /// <summary>
    /// Creates a file symbolic link identified by path that points to pathToTarget.
    /// </summary>
    /// <param name="path">The path where the symbolic link should be created.</param>
    /// <param name="pathToTarget">The path of the target to which the symbolic link points.</param>
    /// <returns></returns>
    public static FileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
    {
        return System.IO.File.CreateSymbolicLink(path, pathToTarget);
    }

    /// <summary>
    /// Deletes the specified file.
    /// </summary>
    /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
    /// <returns></returns>
    public static void Delete(string path)
    {
        System.IO.File.Delete(path);
    }

    /// <summary>
    /// Moves a specified file to a new location, providing the option to specify a new file name.
    /// </summary>
    /// <param name="srcPath">The name of the file to move. Can include a relative or absolute path.</param>
    /// <param name="newPath">The new path and name for the file.</param>
    /// <returns></returns>
    public static void Move(string srcPath, string newPath)
    {
        Move(srcPath, newPath, false);
    }

    /// <summary>
    /// Moves a specified file to a new location, providing the options to specify a new file name and to overwrite the destination file if it already exists.
    /// </summary>
    /// <param name="srcPath">The name of the file to move. Can include a relative or absolute path.</param>
    /// <param name="newPath">The new path and name for the file.</param>
    /// <param name="overwrite">true to overwrite the destination file if it already exists; false otherwise.</param>
    /// <returns></returns>
    public static void Move(string srcPath, string newPath, bool overwrite)
    {
        System.IO.File.Move(srcPath, newPath, overwrite);
    }

    /// <summary>
    /// Copies an existing file to a new file. Overwriting a file of the same name is not allowed.
    /// </summary>
    /// <param name="srcPath">The file to copy.</param>
    /// <param name="newPath">The name of the destination file. This cannot be a directory or an existing file.</param>
    /// <returns></returns>
    public static void Copy(string srcPath, string newPath)
    {
        Copy(srcPath, newPath, false);
    }

    /// <summary>
    /// Copies an existing file to a new file. Overwriting a file of the same name is allowed.
    /// </summary>
    /// <param name="srcPath">The file to copy.</param>
    /// <param name="destPath">The name of the destination file. This cannot be a directory.</param>
    /// <param name="overwrite">true if the destination file can be overwritten; otherwise, false.</param>
    /// <returns></returns>
    public static void Copy(string srcPath, string destPath, bool overwrite)
    {
        System.IO.File.Copy(srcPath, destPath, overwrite);
    }

    /// <summary>
    /// Opens a text file, reads all the text in the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns></returns>
    public static string ReadAllText(string path)
    {
        return ReadAllText(path, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Opens a file, reads all text in the file with the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <returns></returns>
    public static string ReadAllText(string path, System.Text.Encoding encoding)
    {
        return System.IO.File.ReadAllText(path, encoding);
    }

    /// <summary>
    /// Reads the lines of a file.
    /// </summary>
    /// <param name="path">The file to read.</param>
    /// <returns></returns>
    public static IEnumerable<string> ReadLines(string path)
    {
        return ReadLines(path, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Read the lines of a file that has a specified encoding.
    /// </summary>
    /// <param name="path">The file to read.</param>
    /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
    /// <returns></returns>
    public static IEnumerable<string> ReadLines(string path, System.Text.Encoding encoding)
    {
        return System.IO.File.ReadLines(path, encoding);
    }

    /// <summary>
    /// Opens a text file, reads all lines of the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns></returns>
    public static string[] ReadAllLines(string path)
    {
        return ReadAllLines(path, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Opens a file, reads all lines of the file with the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <param name="encoding">The encoding applied to the contents of the file.</param>
    /// <returns></returns>
    public static string[] ReadAllLines(string path, System.Text.Encoding encoding)
    {
        return System.IO.File.ReadAllLines(path, encoding);
    }

    /// <summary>
    /// Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns></returns>
    public static byte[] ReadAllBytes(string path)
    {
        return System.IO.File.ReadAllBytes(path);
    }

    /// <summary>
    /// Creates a new file, writes the specified string to the file, and then closes the file. If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    /// <returns></returns>
    public static void WriteAllText(string path, string contents)
    {
        WriteAllText(path, contents, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    /// <param name="encoding">The encoding to apply to the string.</param>
    /// <returns></returns>
    public static void WriteAllText(string path, string contents, System.Text.Encoding encoding)
    {
        System.IO.File.WriteAllText(path, contents, encoding);
    }

    /// <summary>
    /// Creates a new file, write the specified string array to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="lines">The string array to write to the file.</param>
    /// <returns></returns>
    public static void WriteAllLines(string path, string[] lines)
    {
        WriteAllLines(path, lines, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Creates a new file, writes the specified string array to the file by using the specified encoding, and then closes the file.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="lines">The string array to write to the file.</param>
    /// <param name="encoding">An Encoding object that represents the character encoding applied to the string array.</param>
    /// <returns></returns>
    public static void WriteAllLines(string path, string[] lines, System.Text.Encoding encoding)
    {
        System.IO.File.WriteAllLines(path, lines, encoding);
    }

    /// <summary>
    /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="bytes">The bytes to write to the file.</param>
    /// <returns></returns>
    public static void WriteAllBytes(string path, byte[] bytes)
    {
        System.IO.File.WriteAllBytes(path, bytes);
    }

    /// <summary>
    /// Opens a file, appends the specified string to the file, and then closes the file. If the file does not exist, this method creates a file, writes the specified string to the file, then closes the file.
    /// </summary>
    /// <param name="path">The file to append the specified string to.</param>
    /// <param name="contents">The string to append to the file.</param>
    /// <returns></returns>
    public static void AppendAllText(string path, string contents)
    {
        AppendAllText(path, contents, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Appends the specified string to the file using the specified encoding, creating the file if it does not already exist.
    /// </summary>
    /// <param name="path">The file to append the specified string to.</param>
    /// <param name="contents">The string to append to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <returns></returns>
    public static void AppendAllText(string path, string contents, System.Text.Encoding encoding)
    {
        System.IO.File.AppendAllText(path, contents, encoding);
    }

    /// <summary>
    /// Appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
    /// <param name="lines">The lines to append to the file.</param>
    /// <returns></returns>
    public static void AppendAllLines(string path, IEnumerable<string> lines)
    {
        AppendAllLines(path, lines, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
    /// <param name="lines">The lines to append to the file.</param>
    /// <param name="encoding">The character encoding to use.</param>
    /// <returns></returns>
    public static void AppendAllLines(string path, IEnumerable<string> lines, System.Text.Encoding encoding)
    {
        System.IO.File.AppendAllLines(path, lines, encoding);
    }

    /// <summary>
    /// Determines whether the specified file exists.
    /// </summary>
    /// <param name="path">The file to check.</param>
    /// <returns></returns>
    public static bool Exists(string path)
    {
        return System.IO.File.Exists(path);
    }
}
