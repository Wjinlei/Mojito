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
        return IsMatch(email, @"^(?=.{1,64}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
    }

    /// <summary>
    /// Verify that the given string is a pure letter
    /// </summary>
    /// <param name="letter">String</param>
    /// <returns></returns>
    public static bool IsLetter(string letter)
    {
        return IsMatch(letter, @"^[a-zA-Z]+$");
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
        if (min == 0 || min > max)
            throw new ArgumentOutOfRangeException("min cannot be 0 or greater than max");

        return IsMatch(letter, $"^[a-zA-Z]{{{min},{max}}}$");
    }

    /// <summary>
    /// Verify that the given string is a pure digit
    /// </summary>
    /// <param name="digit">String</param>
    /// <returns></returns>
    public static bool IsDigit(string digit)
    {
        return IsMatch(digit, @"^\d+$");
    }

    /// <summary>
    /// Verify that the given string is a pure digit of the specified length
    /// </summary>
    /// <param name="digit">String</param>
    /// <param name="min">Min length</param>
    /// <param name="max">Max length</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static bool IsDigit(string digit, uint min, uint max)
    {
        if (min == 0 || min > max)
            throw new ArgumentOutOfRangeException("min cannot be 0 or greater than max");

        return IsMatch(digit, $"^\\d{{{min},{max}}}$");
    }

    /// <summary>
    /// Verify that the given string is a combination of letters and numbers
    /// </summary>
    /// <param name="alpha">String</param>
    /// <returns></returns>
    public static bool IsAlpha(string alpha)
    {
        return IsMatch(alpha, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$");
    }

    /// <summary>
    /// Verify that the given string is a combination of letters and numbers of the specified length
    /// </summary>
    /// <param name="alpha">String</param>
    /// <param name="min">Min length</param>
    /// <param name="max">Max length</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static bool IsAlpha(string alpha, uint min, uint max)
    {
        if (min == 0 || min > max)
            throw new ArgumentOutOfRangeException("min cannot be 0 or greater than max");

        return IsMatch(alpha, $"^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{{{min},{max}}}$");
    }

    /// <summary>
    /// Verify that the given string is a combination of letters、numbers and `~!@#$%^&amp;*()_+-={}[]|\:;&quot;'&lt;&gt;,.?/
    /// </summary>
    /// <param name="complex">String</param>
    /// <returns></returns>
    public static bool IsComplex(string complex)
    {
        return IsMatch(complex,
            @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[`~!@#$%^&*()_+\-={}[\]|\\:;""'<>,.?/])[A-Za-z\d`~!@#$%^&*()_+\-={}[\]|\\:;""'<>,.?/]+$");
    }

    /// <summary>
    /// Verify that the given string is a combination of letters、numbers and `~!@#$%^&amp;*()_+-={}[]|\:;&quot;'&lt;&gt;,.?/ of the specified length
    /// </summary>
    /// <param name="complex">String</param>
    /// <param name="min">Min length</param>
    /// <param name="max">Max length</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static bool IsComplex(string complex, uint min, uint max)
    {
        if (min == 0 || min > max)
            throw new ArgumentOutOfRangeException("min cannot be 0 or greater than max");

        return IsMatch(complex,
            $"^(?=.*[A-Za-z])(?=.*\\d)(?=.*[`~!@#$%^&*()_+\\-={{}}[\\]|\\\\:;\"'<>,.?/])[A-Za-z\\d`~!@#$%^&*()_+\\-={{}}[\\]|\\\\:;\"'<>,.?/]{{{min},{max}}}$");
    }

    /// <summary>
    /// Matches a given regular expression
    /// </summary>
    /// <param name="str">String</param>
    /// <param name="regex">Regex</param>
    /// <returns></returns>
    private static bool IsMatch(string str, string regex)
    {
        var regexMatcher = new Regex(regex,
            RegexOptions.None, TimeSpan.FromMilliseconds(150));
        return regexMatcher.Match(str).Success;
    }
}
