using System.Text.RegularExpressions;

namespace Mojito;

public static class Validator
{
    public static bool IsEmail(string email)
    {
        var regex = new Regex(
            @"^(?=.{1,64}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
            RegexOptions.None, TimeSpan.FromMilliseconds(150));

        return regex.Match(email).Success;
    }
}
