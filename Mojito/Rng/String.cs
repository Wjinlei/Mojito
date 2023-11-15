namespace Mojito.Rng;

public static class String
{
    /// <summary>
    /// Generates a random string of Letter
    /// </summary>
    /// <param name="length">The length of a random string generated</param>
    /// <returns></returns>
    public static string Alpha(uint length)
    {
        return Create("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length);
    }

    /// <summary>
    /// Generates a random string of Letter + Number
    /// </summary>
    /// <param name="length">The length of a random string generated</param>
    /// <returns></returns>
    public static string AlphaNumber(uint length)
    {
        return Create("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length);
    }

    /// <summary>
    /// Generates a random string of Number
    /// </summary>
    /// <param name="length">The length of a random string generated</param>
    /// <returns></returns>
    public static string Number(uint length)
    {
        return Create("0123456789", length);
    }

    /// <summary>
    /// Generates a random string of Letter + Number + Special character
    /// </summary>
    /// <param name="length">The length of a random string generated</param>
    /// <returns></returns>
    public static string Complex(uint length)
    {
        return Create("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz~!@#$%^&*()+=,.<>:;{}[]?/", length);
    }

    /// <summary>
    /// Generate random strings (pseudo-random in cryptography terms)
    /// </summary>
    /// <param name="seed">Random seed</param>
    /// <param name="length">The length of a random string generated</param>
    /// <returns></returns>
    public static string Create(string seed, uint length)
    {
        var rnd = new Random();
        return new string(Enumerable.Repeat(seed, (int)length)
            .Select(s => s[rnd.Next(s.Length)]).ToArray());
    }
}
