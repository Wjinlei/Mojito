﻿using System.Text.RegularExpressions;

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
        return Match(email, @"^(?=.{1,64}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
    }

    /// <summary>
    /// Verify that the given string is a pure letter
    /// </summary>
    /// <param name="letter">String</param>
    /// <returns></returns>
    public static bool IsLetter(string letter)
    {
        return Match(letter, @"^[a-zA-Z]+$");
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

        return Match(letter, $"^[a-zA-Z]{{{min},{max}}}$");
    }

    /// <summary>
    /// Matches a given regular expression
    /// </summary>
    /// <param name="str">String</param>
    /// <param name="regex">Regex</param>
    /// <returns></returns>
    private static bool Match(string str, string regex)
    {
        var regexMatcher = new Regex(regex,
            RegexOptions.None, TimeSpan.FromMilliseconds(150));
        return regexMatcher.Match(str).Success;
    }
}
