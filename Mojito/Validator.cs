using System.Text.RegularExpressions;

namespace Mojito;

public static class Validator
{
    public static bool IsEmail(string email)
    {
        var regex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.None, TimeSpan.FromMilliseconds(150));

        return regex.Match(email).Success;
    }
}
