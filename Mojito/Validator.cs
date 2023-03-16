using System.Text.RegularExpressions;

namespace Mojito;

public static class Validator
{
    /// <summary>
    /// Verify that the given string is email
    /// </summary>
    /// <param name="email">String</param>
    /// <returns></returns>
    public static bool IsEmail(string email)
    {
        var regex = new Regex(
            @"^(?=.{1,64}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
            RegexOptions.None, TimeSpan.FromMilliseconds(150));

        return regex.Match(email).Success;
    }

    /// <summary>
    /// Verify that the given string is a pure letter
    /// </summary>
    /// <param name="letter">String</param>
    /// <returns></returns>
    public static bool IsLetter(string letter)
    {
        var regex = new Regex(
            @"^[a-zA-Z]+$",
            RegexOptions.None, TimeSpan.FromMilliseconds(150));

        return regex.Match(letter).Success;
    }

    /// <summary>
    /// Verify that the given string is a pure letter of the specified length
    /// </summary>
    /// <param name="letter">String</param>
    /// <param name="min">Min length</param>
    /// <param name="max">Max length</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static bool IsLetter(string letter, uint min, uint max)
    {
        if (min == 0)
            throw new ArgumentOutOfRangeException("min cannot equal 0");
        if (min > max)
            throw new ArgumentOutOfRangeException("min cannot be greater than max");

        var re = "^[a-zA-Z]{" + min + "," + max + "}$";
        var regex = new Regex(re, RegexOptions.None, TimeSpan.FromMilliseconds(150));

        return regex.Match(letter).Success;
    }
}
